namespace ProcessingTimeCalc.Operations.Parameters
{
    partial class ParameterCollectionItem : ParameterItem
    {
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            dropDown = new ComboBox();
            SuspendLayout();
            // 
            // dropDown
            // 
            dropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            dropDown.FlatStyle = FlatStyle.Flat;
            dropDown.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dropDown.FormattingEnabled = true;
            dropDown.Location = new Point(3, 39);
            dropDown.Name = "dropDown";
            dropDown.Size = new Size(134, 21);
            dropDown.TabIndex = 7;
            dropDown.SelectionChangeCommitted += OnDropDownSelectionChangeCommitted;
            // 
            // ParameterCollectionItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            Controls.Add(dropDown);
            Name = "ParameterCollectionItem";
            Controls.SetChildIndex(dropDown, 0);
            ResumeLayout(false);
        }

        private ComboBox dropDown;
    }
}
