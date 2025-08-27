using ProcessingTimeCalc.Operations.Parameters;
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

namespace ProcessingTimeCalc.Operations.Collections
{
    public partial class CollectionItem : UserControl, IPoolableObject
    {
        /// <summary>
        /// Вызывается при изменении выбранного значения
        /// </summary>
        public Action<CollectionItem>? OnSelectedObjectChanged;
        public bool IsActive { get; set; }
        internal Collection? Collection => collection;
        private Collection? collection = null;
        /// <summary>
        /// Выбранное значение
        /// </summary>
        public object? SelectedObject => selectedObject;
        private object? selectedObject = null;
        /// <summary>
        /// Выбранное значение (текстовое отображение)
        /// </summary>
        public string SelectedValue => selectedValue;
        private string selectedValue = "";

        public CollectionItem()
        {
            InitializeComponent();
        }
        public void OnPoolEnable() { }
        public void OnPoolDisable() { }
        internal void Initialize(Collection collection)
        {
            this.collection = collection;
            UpdateUI();
        }
        private void UpdateUI()
        {
            nameText.Text = collection!.Name;
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
            selectedValue = dropDown.GetItemText(newObject);
            collection!.SetValue(newObject);
            OnSelectedObjectChanged?.Invoke(this);
        }
    }
}
