namespace ProcessingTimeCalc.Operations.Parameters
{
    partial class ParameterItem
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
        protected virtual void InitializeComponent()
        {
            nameText = new Label();
            unitsText = new Label();
            valueInput = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // nameText
            // 
            nameText.Anchor = AnchorStyles.Top;
            nameText.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            nameText.Location = new Point(3, 9);
            nameText.MaximumSize = new Size(135, 0);
            nameText.Name = "nameText";
            nameText.Size = new Size(134, 36);
            nameText.TabIndex = 5;
            nameText.Text = "Название, об. ";
            nameText.TextAlign = ContentAlignment.TopCenter;
            // 
            // unitsText
            // 
            unitsText.Anchor = AnchorStyles.Left;
            unitsText.AutoSize = true;
            unitsText.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            unitsText.ForeColor = SystemColors.ControlText;
            unitsText.Location = new Point(78, 5);
            unitsText.MaximumSize = new Size(72, 0);
            unitsText.Name = "unitsText";
            unitsText.RightToLeft = RightToLeft.No;
            unitsText.Size = new Size(22, 17);
            unitsText.TabIndex = 4;
            unitsText.Text = "ед";
            // 
            // valueInput
            // 
            valueInput.Anchor = AnchorStyles.Left;
            valueInput.BorderStyle = BorderStyle.None;
            valueInput.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            valueInput.Location = new Point(3, 5);
            valueInput.MaxLength = 10;
            valueInput.Name = "valueInput";
            valueInput.Size = new Size(71, 18);
            valueInput.TabIndex = 3;
            valueInput.Text = "0";
            valueInput.TextAlign = HorizontalAlignment.Right;
            valueInput.TextChanged += OnValueInputTextChanged;
            valueInput.KeyPress += OnValueInputKeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(nameText);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(140, 98);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(unitsText);
            panel2.Controls.Add(valueInput);
            panel2.Location = new Point(3, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(134, 30);
            panel2.TabIndex = 6;
            // 
            // ParameterItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            Controls.Add(panel1);
            Name = "ParameterItem";
            Size = new Size(144, 102);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected Label nameText;
        protected Label unitsText;
        private TextBox valueInput;
        private Panel panel1;
        private Panel panel2;
    }
}
