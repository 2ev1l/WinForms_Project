namespace ProcessingTimeCalc.Operations.Collections
{
    partial class CollectionItem
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
            nameText = new Label();
            panel1 = new Panel();
            dropDown = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nameText
            // 
            nameText.Anchor = AnchorStyles.Top;
            nameText.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            nameText.Location = new Point(3, 9);
            nameText.MaximumSize = new Size(135, 0);
            nameText.Name = "nameText";
            nameText.Size = new Size(134, 32);
            nameText.TabIndex = 5;
            nameText.Text = "Название";
            nameText.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dropDown);
            panel1.Controls.Add(nameText);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(140, 98);
            panel1.TabIndex = 6;
            // 
            // dropDown
            // 
            dropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            dropDown.FlatStyle = FlatStyle.Flat;
            dropDown.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dropDown.FormattingEnabled = true;
            dropDown.Location = new Point(3, 67);
            dropDown.Name = "dropDown";
            dropDown.Size = new Size(134, 21);
            dropDown.TabIndex = 6;
            dropDown.SelectionChangeCommitted += OnDropDownSelectionChangeCommitted;
            // 
            // CollectionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            Controls.Add(panel1);
            Name = "CollectionItem";
            Size = new Size(144, 102);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label nameText;
        private Panel panel1;
        private ComboBox dropDown;
    }
}
