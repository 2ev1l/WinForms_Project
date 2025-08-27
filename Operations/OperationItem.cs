using ProcessingTimeCalc.Operations.Collections;
using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using ProcessingTimeCalc.Universal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessingTimeCalc.Operations
{
    public partial class OperationItem : UserControl, IPoolableObject
    {
        /// <summary>
        /// Вызывается при изменении параметра операции
        /// </summary>
        public Action<OperationItem, ParameterItem>? OnParameterChanged;
        /// <summary>
        /// Вызывается при изменении выбранных данных коллекции
        /// </summary>
        public Action<OperationItem, CollectionItem>? OnCollectionChanged;

        public bool IsActive { get; set; }
        private readonly List<Operation>? operations = null;
        internal Operation? SelectedOperation => selectedOperation;
        private Operation? selectedOperation = null;
        internal IReadOnlyCollection<ParameterItem> Parameters => parameters.Objects;
        private readonly ObjectPool<ParameterItem> parameters = new();
        internal ProcessingInfo? CombinationInfo => combinationInfo;
        private ProcessingInfo? combinationInfo;
        internal IReadOnlyCollection<CollectionItem> Collections => collections.Objects;
        private readonly ObjectPool<CollectionItem> collections = new();

        public OperationItem()
        {
            InitializeComponent();
            operations = MainForm.GetAllOperations();
            operationDropDown.DataSource = operations;
            operationDropDown.DisplayMember = "Name";
            ChangeSelectedOperation(operations[0]);
        }

        public void OnPoolEnable()
        {
            descriptionText.Text = "Описание";
        }
        public void OnPoolDisable()
        {

        }
        private void InvokeParameterChange(ParameterItem item) => OnParameterChanged?.Invoke(this, item);
        private void InvokeCollectionChange(CollectionItem item) => OnCollectionChanged?.Invoke(this, item);
        private void OnOperationDropDownSelectionChangeCommitted(object sender, EventArgs e)
        {
            if (operationDropDown.SelectedItem is not Operation newOp) return;
            ChangeSelectedOperation(newOp);
        }
        /// <summary>
        /// Смена текущей операции
        /// </summary>
        /// <param name="newOperation"></param>
        public void ChangeSelectedOperation(Operation newOperation)
        {
            selectedOperation = newOperation;
            parametersLayoutGroup.Controls.Clear();
            parameters.DisableObjects();
            collections.DisableObjects();

            InitializeCollections();
            InitializeParameters();
        }
        private void InitializeParameters()
        {
            foreach (Parameter parameter in selectedOperation!.Parameters)
            {
                InitializeParameter(parameter);
            }
        }
        /// <summary>
        /// Инициализация параметра в UI
        /// </summary>
        /// <param name="parameter"></param>
        private void InitializeParameter(Parameter parameter)
        {
            ParameterItem item = parameter switch
            {
                ParameterCollection => parameters.GetObject<ParameterCollectionItem>(),
                _ => parameters.GetObject()
            };

            item.OnInputChanged -= InvokeParameterChange;
            item.Initialize(parameter, this.selectedOperation!);
            item.OnInputChanged += InvokeParameterChange;
            parametersLayoutGroup.Controls.Add(item);
        }
        private void InitializeCollections()
        {
            Operation operation = selectedOperation!;
            InitializeCollection(new ToolTypes(operation));
            InitializeCollection(new ProcessingModes(operation));
            InitializeCollection(new Materials(operation));
            InitializeCollection(new ToolNames(operation));
        }
        /// <summary>
        /// Инициализация коллекции в UI
        /// </summary>
        /// <param name="collection"></param>
        private void InitializeCollection(ImportCollection collection)
        {
            CollectionItem item = collections.GetObject();
            item.OnSelectedObjectChanged -= OnSelectedCollectionObjectChanged;
            item.Initialize(collection);
            item.OnSelectedObjectChanged += OnSelectedCollectionObjectChanged;
            parametersLayoutGroup.Controls.Add(item);
        }
        private void OnSelectedCollectionObjectChanged(CollectionItem item)
        {
            CollectionItem toolName = collections.Find(x => x.Collection is ToolNames)!;
            CollectionItem toolTypes = collections.Find(x => x.Collection is ToolTypes)!;
            CollectionItem materials = collections.Find(x => x.Collection is Materials)!;
            CollectionItem processingModes = collections.Find(x => x.Collection is ProcessingModes)!;
            ToolType toolType = (ToolType)toolTypes.SelectedObject!;
            Material material = (Material)materials.SelectedObject!;
            ProcessingMode pm = (ProcessingMode)processingModes.SelectedObject!;
            combinationInfo = ToolsData.Instance.FindInfo(toolName.SelectedValue, toolType.CSVName, material.CSVName, pm.CSVName);
            foreach (ParameterItem p in parameters.Objects)
            {
                p.Parameter!.OnProcessingInfoChanged(combinationInfo);
            }
            selectedOperation!.OnProcessingInfoChanged(combinationInfo);
            InvokeCollectionChange(item);
        }
    }
}
