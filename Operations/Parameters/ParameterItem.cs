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

namespace ProcessingTimeCalc.Operations.Parameters
{
    public partial class ParameterItem : UserControl, IPoolableObject
    {
        public Action<ParameterItem>? OnInputChanged;
        public bool IsActive { get; set; }
        internal Parameter? Parameter => parameter;
        private Parameter? parameter = null;

        public ParameterItem()
        {
            InitializeComponent();
        }
        public void OnPoolEnable() { }
        public void OnPoolDisable() { }

        internal virtual void Initialize(Parameter parameter, Operation operation)
        {
            if (this.parameter != null)
                this.parameter.OnValueChanged -= OnParameterValueChanged;
            this.parameter = parameter;
            this.parameter.OnValueChanged += OnParameterValueChanged;
            UpdateUI();
        }
        protected virtual void UpdateUI()
        {
            nameText.Text = parameter!.Name;
            unitsText.Text = parameter!.UnitsName;
            valueInput.Text = parameter!.DefaultValue == int.MinValue ? Configuration.Instance.UIData.DefaultInputValue.ToString() : parameter!.DefaultValue.ToString("F2");
            if (parameter != null)
            {
                valueInput.Enabled = !parameter.ReadOnly;
                parameter.TrySaveInput(valueInput.Text);
            }

        }

        private void OnValueInputKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == '.') && (valueInput.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
            }
        }
        public void ChangeInput(string newValue)
        {
            valueInput.Text = newValue;
            parameter?.TrySaveInput(valueInput.Text);
        }
        private void OnValueInputTextChanged(object sender, EventArgs e) => OnValueInputChanged();
        private void OnParameterValueChanged(float newValue)
        {
            valueInput.Text = newValue.ToString("F2");
            OnInputChanged?.Invoke(this);
        }
        private void OnValueInputChanged()
        {
            parameter?.TrySaveInput(valueInput.Text);
        }
    }
}
