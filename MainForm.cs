using PdfSharp.Drawing;
using ProcessingTimeCalc.Operations;
using ProcessingTimeCalc.Operations.Collections;
using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using ProcessingTimeCalc.Universal;
using System.Text;

namespace ProcessingTimeCalc
{
    public partial class MainForm : Form
    {
        private static readonly string RequireErrorFixText = "Необходимо исправить ошибки";
        private static readonly string timeUnitsText = "МЧ";
        private readonly ObjectPool<OperationItem> usedOperations = new();
        private StateMachine<Panel> ControlPanelStateMachine
        {
            get
            {
                controlPanelStateMachine ??= new StateMachine<Panel>(
                    new List<Panel> { controlPanelMain, controlPanelCSV },
                    controlPanelMain,
                    (panel, b) => panel.Visible = b);
                return controlPanelStateMachine!;
            }
        }
        private StateMachine<Panel>? controlPanelStateMachine = null;
        private bool hasErrors = false;
        private float timeIncreasePercent = 0;

        public MainForm()
        {
            InitializeComponent();
            try { ToolsData.Instance.TryLoadDataFromConfiguration(); }
            catch { }

            FixControlPanelState();
        }

        internal static List<Operation> GetAllOperations() => new()
        {
            new Grooving(),
            new HoleMiling(),
            new Drilling(),
            new Centering(),
            new Countersinking(),
            new Marking(),
            new Reaming(),
            new ThreadMiling(),
        };
        /// <summary>
        /// Корректировка ввода числовых значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateInputKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
            }
        }
        private void OnIncreaseTimeInputTextChanged(object sender, EventArgs e) => SaveTimeIncreasePercent();
        /// <summary>
        /// Сохранение % увеличения итогового времени
        /// </summary>
        private void SaveTimeIncreasePercent()
        {
            try { timeIncreasePercent = CustomMath.ConvertToFloat(increaseTimeInputField.Text); }
            catch { timeIncreasePercent = 0; }
        }
        public void OnCalculateButtonClick(object sender, EventArgs e)
        {
            if (hasErrors)
            {
                totalTimeText.Text = RequireErrorFixText;
                return;
            }
            ShowOperationsTime();
        }
        /// <summary>
        /// Вывод результатов подсчета времени операций
        /// </summary>
        private void ShowOperationsTime()
        {
            float t = CalculateOperationsTime();
            if (t < 0)
            {
                totalTimeText.Text = "Не удалось расчитать время";
                return;
            }
            totalTimeText.Text = $"{Extensions.ToMachineTime(t)} {timeUnitsText}";
        }
        private void OnSavePDFButtonClicked(object sender, EventArgs e) => TryCreatePDF();
        private void TryCreatePDF()
        {
            if (hasErrors)
            {
                totalTimeText.Text = RequireErrorFixText;
                return;
            }
            if (CalculateOperationsTime() < 0)
                return;
            CreatePDF();
        }
        /// <summary>
        /// Создание отчета
        /// </summary>
        private void CreatePDF()
        {
            PDFWriter writer = new();
            writer.Open();
            writer.SetTitle("Расчет времени процессов");
            float result = 0;
            writer.AddPage();
            int counter = 0;
            float totalTime = CalculateOperationsTime();
            foreach (OperationItem op in operationsLayoutGroup.Controls.Cast<OperationItem>())
            {
                if (!op.IsActive) continue;
                Operation? selectedOperation = op.SelectedOperation;
                if (selectedOperation == null) continue;
                writer.ResetTable();
                counter++;
                float calculatedTime = selectedOperation.CalculateTime();
                result += calculatedTime;
                writer.AddHeader($"Операция #{counter}", 2);
                writer.AddHeader($"{selectedOperation.Name}", 3);
                string desc = op.descriptionText.Text;
                if (desc.Length > 0 && !desc.Equals("Описание"))
                {
                    writer.AddParagraph(desc, 2);
                }
                writer.AddSpace(0.3f);
                foreach (CollectionItem c in op.Collections)
                {
                    if (!c.IsActive) continue;
                    writer.AddTableRow(2, 1, c.Collection!.Name, c.SelectedValue);
                }
                bool hasDuplicates = false;
                float duplicatesCount = 0;

                foreach (ParameterItem p in op.Parameters)
                {
                    if (!p.IsActive) continue;
                    Parameter? parameter = p.Parameter;
                    if (parameter == null) continue;
                    if (!parameter.IsCorrect) continue;
                    float paramValue = parameter.Value;
                    writer.AddTableRow(2, 1, parameter.Name, $"{paramValue:F2} {parameter.UnitsName}");
                    if (parameter is DuplicateAmount)
                    {
                        hasDuplicates = true;
                        duplicatesCount = paramValue;
                    }
                }
                writer.AddSpace(0.4f);
                writer.AddTableRow(2, 1, "Время операции", $"{Extensions.ToMachineTime(calculatedTime)} {timeUnitsText} ({calculatedTime / totalTime * 100:F1}%)");
                if (hasDuplicates && duplicatesCount > 1)
                {
                    float timePerSingle = calculatedTime / duplicatesCount;
                    writer.AddTableRow(2, 1, "Время операции (за ед.)", $"{Extensions.ToMachineTime(timePerSingle)} {timeUnitsText} ({timePerSingle / totalTime * 100:F1}%)");
                }
                writer.AddTableRow(2, 1, "Накопленное время", $"{Extensions.ToMachineTime(result)} {timeUnitsText} ({result / totalTime * 100:F1}%)");
                writer.AddSpace(1);
                writer.AddLine(XKnownColor.Black, 1f);
                writer.AddSpace(1);
            }
            writer.AddHeader("Итоговое время", 3);
            writer.AddParagraph($"{Extensions.ToMachineTime(result)} {timeUnitsText}");
            if (timeIncreasePercent > 0)
                writer.AddParagraph($"{Extensions.ToMachineTime(result * (1 + timeIncreasePercent / 100))} {timeUnitsText} (+{timeIncreasePercent:F2}%)");
            writer.Save();
        }
        /// <summary>
        /// Подсчет времени операций
        /// </summary>
        /// <returns>Итоговое время всех операций</returns>
        private float CalculateOperationsTime()
        {
            float result = 0;
            foreach (OperationItem item in usedOperations.Objects)
            {
                if (!item.IsActive) continue;
                if (item.SelectedOperation == null) continue;
                result += item.SelectedOperation.CalculateTime();
            }
            return result * (1 + timeIncreasePercent / 100);
        }
        public void OnAddOperationButtonClick(object sender, EventArgs e)
        {
            AddOperation();
        }
        public void OnRemoveOperationButtonClick(object? sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender is not Button btn) return;
            OperationItem? selected = null;
            foreach (OperationItem op in usedOperations.Objects)
            {
                if (op.removeOperationButton != btn) continue;
                selected = op;
                break;
            }
            if (selected == null) return;
            RemoveOperation(selected);
            if (usedOperations.GetActiveObjectsCount() == 0)
                AddOperation();
        }
        private void OnOperationSelectChanged(object? sender, EventArgs e)
        {
            RecalculateErrors();
        }
        /// <summary>
        /// Добавление новой операции
        /// </summary>
        private void AddOperation()
        {
            OperationItem item = usedOperations.GetObject();
            operationsLayoutGroup.Controls.Add(item);
            item.removeOperationButton.Click += OnRemoveOperationButtonClick;
            item.operationDropDown.SelectionChangeCommitted += OnOperationSelectChanged;
            item.OnParameterChanged += OnParameterChanged;
            item.OnCollectionChanged += OnCollectionChanged;
            RecalculateErrors();
        }
        /// <summary>
        /// Удаление существующей операции
        /// </summary>
        /// <param name="item"></param>
        private void RemoveOperation(OperationItem item)
        {
            item.IsActive = false;
            operationsLayoutGroup.Controls.Remove(item);
            item.removeOperationButton.Click -= OnRemoveOperationButtonClick;
            item.operationDropDown.SelectionChangeCommitted -= OnOperationSelectChanged;
            item.OnParameterChanged -= OnParameterChanged;
            item.OnCollectionChanged -= OnCollectionChanged;
            RecalculateErrors();
        }
        private void OnParameterChanged(OperationItem operation, ParameterItem parameter)
        {
            RecalculateErrors();
        }
        private void OnCollectionChanged(OperationItem operation, CollectionItem collection)
        {
            RecalculateErrors();
        }
        /// <summary>
        /// Проверка исключений
        /// </summary>
        private void RecalculateErrors()
        {
            StringBuilder sb = new();
            void AddBreak()
            {
                sb.AppendLine($"============================");
            }
            foreach (OperationItem op in usedOperations.Objects)
            {
                if (!op.IsActive) continue;
                if (op.CombinationInfo == null)
                {
                    sb.AppendLine($"{op.SelectedOperation!.Name} - Не удалось найти комбинацию заданных параметров");
                    AddBreak();
                }
                foreach (ParameterItem p in op.Parameters)
                {
                    if (!p.IsActive) continue;
                    if (p.Parameter!.IsCorrect)
                    {
                        continue;
                    }
                    sb.AppendLine($"{op.SelectedOperation!.Name} - {p.Parameter.Name} : {p.Parameter.GetCorrectInputText()}");
                    AddBreak();
                }
            }
            errorsText.Text = sb.ToString();
            hasErrors = errorsText.Text.Length > 0;
        }

        private void OnLoadCSVButtonClicked(object sender, EventArgs e)
        {
            try
            {
                LoadCSV();
                errorsText.Text = "";
            }
            catch
            {
                errorsText.Text = "Не удалось обработать CSV";
            }
            FixControlPanelState();
        }
        private static void LoadCSV() => ToolsData.Instance.TryLoadData();
        /// <summary>
        /// Отображени GUI в зависимости от этапа загрузки данных
        /// </summary>
        private void FixControlPanelState()
        {
            Panel activePanel = (ToolsData.Instance.IsDataLoaded) ? controlPanelMain : controlPanelCSV;
            ControlPanelStateMachine.ApplyState(activePanel);
        }
    }
}
