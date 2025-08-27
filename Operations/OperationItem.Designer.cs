namespace ProcessingTimeCalc.Operations
{
    partial class OperationItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationItem));
            operationDropDown = new ComboBox();
            removeOperationButton = new Button();
            panel1 = new Panel();
            descriptionText = new TextBox();
            pictureBox1 = new PictureBox();
            parametersLayoutGroup = new FlowLayoutPanel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // operationDropDown
            // 
            operationDropDown.DropDownHeight = 120;
            operationDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            operationDropDown.FlatStyle = FlatStyle.Popup;
            operationDropDown.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            operationDropDown.FormattingEnabled = true;
            operationDropDown.IntegralHeight = false;
            operationDropDown.Location = new Point(3, 3);
            operationDropDown.Name = "operationDropDown";
            operationDropDown.RightToLeft = RightToLeft.No;
            operationDropDown.Size = new Size(231, 28);
            operationDropDown.TabIndex = 0;
            operationDropDown.SelectionChangeCommitted += OnOperationDropDownSelectionChangeCommitted;
            // 
            // removeOperationButton
            // 
            removeOperationButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeOperationButton.BackColor = Color.LightCoral;
            removeOperationButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            removeOperationButton.Location = new Point(528, 0);
            removeOperationButton.Name = "removeOperationButton";
            removeOperationButton.Size = new Size(32, 32);
            removeOperationButton.TabIndex = 1;
            removeOperationButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(descriptionText);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(operationDropDown);
            panel1.Controls.Add(removeOperationButton);
            panel1.Location = new Point(23, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 55);
            panel1.TabIndex = 2;
            // 
            // descriptionText
            // 
            descriptionText.BorderStyle = BorderStyle.FixedSingle;
            descriptionText.ForeColor = SystemColors.WindowFrame;
            descriptionText.Location = new Point(240, 3);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.Size = new Size(282, 28);
            descriptionText.TabIndex = 3;
            descriptionText.Text = "Описание";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.LightCoral;
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(537, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(14, 14);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // parametersLayoutGroup
            // 
            parametersLayoutGroup.Anchor = AnchorStyles.Bottom;
            parametersLayoutGroup.AutoScroll = true;
            parametersLayoutGroup.Location = new Point(23, 73);
            parametersLayoutGroup.Name = "parametersLayoutGroup";
            parametersLayoutGroup.Size = new Size(560, 127);
            parametersLayoutGroup.TabIndex = 3;
            parametersLayoutGroup.WrapContents = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(parametersLayoutGroup);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(598, 203);
            panel2.TabIndex = 4;
            // 
            // OperationItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            Controls.Add(panel2);
            Name = "OperationItem";
            Size = new Size(602, 207);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public ComboBox operationDropDown;
        public Button removeOperationButton;
        private Panel panel1;
        private FlowLayoutPanel parametersLayoutGroup;
        private PictureBox pictureBox1;
        private Panel panel2;
        public TextBox descriptionText;
    }
}
