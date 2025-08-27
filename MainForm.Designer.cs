namespace ProcessingTimeCalc
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            operationsLayoutGroup = new FlowLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            controlPanelMain = new Panel();
            label5 = new Label();
            label3 = new Label();
            increaseTimeInputField = new TextBox();
            label4 = new Label();
            totalTimeText = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            calculateButton = new Button();
            addOperationButton = new Button();
            savePDFButton = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            errorsText = new Label();
            controlPanelCSV = new Panel();
            loadCSVButton = new Button();
            panel1.SuspendLayout();
            controlPanelMain.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            controlPanelCSV.SuspendLayout();
            SuspendLayout();
            // 
            // operationsLayoutGroup
            // 
            operationsLayoutGroup.AutoScroll = true;
            operationsLayoutGroup.BackColor = SystemColors.ButtonHighlight;
            operationsLayoutGroup.Dock = DockStyle.Right;
            operationsLayoutGroup.FlowDirection = FlowDirection.TopDown;
            operationsLayoutGroup.Location = new Point(476, 0);
            operationsLayoutGroup.Name = "operationsLayoutGroup";
            operationsLayoutGroup.Size = new Size(631, 668);
            operationsLayoutGroup.TabIndex = 0;
            operationsLayoutGroup.WrapContents = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(68, 23);
            label1.Name = "label1";
            label1.Size = new Size(318, 25);
            label1.TabIndex = 1;
            label1.Text = "Расчет времени обработки деталей";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(controlPanelMain);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(controlPanelCSV);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 668);
            panel1.TabIndex = 1;
            // 
            // controlPanelMain
            // 
            controlPanelMain.Anchor = AnchorStyles.Bottom;
            controlPanelMain.Controls.Add(label5);
            controlPanelMain.Controls.Add(label3);
            controlPanelMain.Controls.Add(increaseTimeInputField);
            controlPanelMain.Controls.Add(label4);
            controlPanelMain.Controls.Add(totalTimeText);
            controlPanelMain.Controls.Add(flowLayoutPanel1);
            controlPanelMain.Location = new Point(12, 537);
            controlPanelMain.Name = "controlPanelMain";
            controlPanelMain.Size = new Size(448, 119);
            controlPanelMain.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(183, 28);
            label5.Name = "label5";
            label5.Size = new Size(23, 21);
            label5.TabIndex = 12;
            label5.Text = "%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 30);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 11;
            label3.Text = "Увеличить на:";
            // 
            // increaseTimeInputField
            // 
            increaseTimeInputField.BorderStyle = BorderStyle.FixedSingle;
            increaseTimeInputField.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            increaseTimeInputField.Location = new Point(124, 27);
            increaseTimeInputField.Name = "increaseTimeInputField";
            increaseTimeInputField.RightToLeft = RightToLeft.Yes;
            increaseTimeInputField.Size = new Size(58, 25);
            increaseTimeInputField.TabIndex = 10;
            increaseTimeInputField.Text = "0";
            increaseTimeInputField.TextChanged += OnIncreaseTimeInputTextChanged;
            increaseTimeInputField.KeyPress += ValidateInputKeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 1);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 4;
            label4.Text = "Итоговое время:";
            // 
            // totalTimeText
            // 
            totalTimeText.AutoSize = true;
            totalTimeText.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            totalTimeText.Location = new Point(124, 0);
            totalTimeText.Name = "totalTimeText";
            totalTimeText.Size = new Size(22, 21);
            totalTimeText.TabIndex = 5;
            totalTimeText.Text = "...";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(calculateButton);
            flowLayoutPanel1.Controls.Add(addOperationButton);
            flowLayoutPanel1.Controls.Add(savePDFButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(-3, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(451, 49);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // calculateButton
            // 
            calculateButton.BackColor = Color.WhiteSmoke;
            calculateButton.FlatStyle = FlatStyle.Popup;
            calculateButton.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            calculateButton.Location = new Point(310, 3);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(138, 40);
            calculateButton.TabIndex = 6;
            calculateButton.Text = "Рассчитать";
            calculateButton.UseVisualStyleBackColor = false;
            calculateButton.Click += OnCalculateButtonClick;
            // 
            // addOperationButton
            // 
            addOperationButton.BackColor = SystemColors.GradientInactiveCaption;
            addOperationButton.FlatStyle = FlatStyle.Popup;
            addOperationButton.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addOperationButton.Location = new Point(110, 3);
            addOperationButton.Name = "addOperationButton";
            addOperationButton.Size = new Size(194, 40);
            addOperationButton.TabIndex = 7;
            addOperationButton.Text = "Добавить операцию";
            addOperationButton.UseVisualStyleBackColor = false;
            addOperationButton.Click += OnAddOperationButtonClick;
            // 
            // savePDFButton
            // 
            savePDFButton.BackColor = SystemColors.GradientActiveCaption;
            savePDFButton.FlatStyle = FlatStyle.Popup;
            savePDFButton.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            savePDFButton.Location = new Point(3, 3);
            savePDFButton.Name = "savePDFButton";
            savePDFButton.Size = new Size(101, 40);
            savePDFButton.TabIndex = 8;
            savePDFButton.Text = "Сохранить";
            savePDFButton.UseVisualStyleBackColor = false;
            savePDFButton.Click += OnSavePDFButtonClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(448, 68);
            panel2.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.2200775F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.77992F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(errorsText, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 83);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.9891052F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.01089334F));
            tableLayoutPanel1.Size = new Size(448, 431);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Ошибки:";
            // 
            // errorsText
            // 
            errorsText.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            errorsText.ForeColor = Color.DarkRed;
            errorsText.Location = new Point(124, 0);
            errorsText.MaximumSize = new Size(320, 0);
            errorsText.Name = "errorsText";
            errorsText.Size = new Size(319, 431);
            errorsText.TabIndex = 3;
            errorsText.Text = "...";
            // 
            // controlPanelCSV
            // 
            controlPanelCSV.Anchor = AnchorStyles.Bottom;
            controlPanelCSV.Controls.Add(loadCSVButton);
            controlPanelCSV.Location = new Point(12, 573);
            controlPanelCSV.Name = "controlPanelCSV";
            controlPanelCSV.Size = new Size(448, 83);
            controlPanelCSV.TabIndex = 12;
            // 
            // loadCSVButton
            // 
            loadCSVButton.BackColor = SystemColors.GradientActiveCaption;
            loadCSVButton.FlatStyle = FlatStyle.Popup;
            loadCSVButton.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loadCSVButton.Location = new Point(124, 24);
            loadCSVButton.Name = "loadCSVButton";
            loadCSVButton.Size = new Size(206, 40);
            loadCSVButton.TabIndex = 9;
            loadCSVButton.Text = "Загрузить данные из CSV";
            loadCSVButton.UseVisualStyleBackColor = false;
            loadCSVButton.Click += OnLoadCSVButtonClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1107, 668);
            Controls.Add(panel1);
            Controls.Add(operationsLayoutGroup);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1123, 250);
            Name = "MainForm";
            Text = "Расчет времени обработки деталей";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            controlPanelMain.ResumeLayout(false);
            controlPanelMain.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            controlPanelCSV.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel operationsLayoutGroup;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label errorsText;
        private Label label4;
        private Label totalTimeText;
        private Button addOperationButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel controlPanelMain;
        private Button calculateButton;
        private Button savePDFButton;
        private Panel controlPanelCSV;
        private Button loadCSVButton;
        private Label label3;
        private TextBox increaseTimeInputField;
        private Label label5;
    }
}
