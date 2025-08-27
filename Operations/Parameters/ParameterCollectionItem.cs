using ProcessingTimeCalc.Operations.Collections;

namespace ProcessingTimeCalc.Operations.Parameters
{
    public partial class ParameterCollectionItem : ParameterItem
    {
        private ParameterCollection ParameterCollection => (ParameterCollection)Parameter!;
        public object? SelectedObject => selectedObject;
        private object? selectedObject = null;
        public string SelectedValue => selectedValue;
        private string selectedValue = "";


        internal override void Initialize(Parameter parameter, Operation operation)
        {
            base.Initialize(parameter, operation);
            ParameterCollection.Initialize(operation);
            Collection collection = ParameterCollection.Collection!;
            dropDown.DataSource = collection.DataSource;
            dropDown.DisplayMember = collection.DisplayMember;
            ChangeSelectedObject(collection.DefaultValue);
        }
        private void OnDropDownSelectionChangeCommitted(object sender, EventArgs e)
        {
            ChangeSelectedObject(dropDown.SelectedItem);
        }
        /// <summary>
        /// Изменить выбранный элемент коллекции
        /// </summary>
        /// <param name="newObject"></param>
        public void ChangeSelectedObject(object newObject)
        {
            selectedObject = newObject;
            ParameterCollection.Collection!.SetValue(newObject);
            selectedValue = dropDown.GetItemText(newObject);
            unitsText.Text = ParameterCollection.UnitsName;
        }
    }
}
