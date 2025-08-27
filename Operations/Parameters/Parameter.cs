using ProcessingTimeCalc.Processing;
using ProcessingTimeCalc.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Parameters
{
    /// <summary>
    /// Используемый в операциях параметр для расчета времени
    /// </summary>
    public abstract class Parameter
    {
        /// <summary>
        /// Вызывается при изменении значения параметра
        /// </summary>
        public Action<float>? OnValueChanged;
        protected static readonly float minValue = 0.000001f;
        protected static readonly float maxValue = 1e+10f;
        /// <summary>
        /// Название параметра
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Единицы измерения параметра
        /// </summary>
        public abstract string UnitsName { get; }
        /// <summary>
        /// Доступен ли параметр для ввода из GUI
        /// </summary>
        public virtual bool ReadOnly => false;
        public bool IsCorrect => isCorrect;
        private bool isCorrect = false;
        /// <summary>
        /// Текущее значение параметра
        /// </summary>
        public float Value => value;
        private float value = 0;
        public float DefaultValue { get; } = int.MinValue;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Текст исключения (при наличии)</returns>
        public virtual string GetCorrectInputText()
        {
            if (value > maxValue) return "Значение слишком большое.";
            if (value < minValue) return "Значение должно быть больше 0.";
            return "Не числовое значение";
        }
        /// <summary>
        /// Проверить доступность значения
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Доступно ли значение</returns>
        protected virtual bool ValidateInput(float input)
        {
            if (input > maxValue) return false;
            if (input < minValue) return false;
            return true;
        }
        /// <summary>
        /// Сохранить ввод
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Был ли ввод сохранен</returns>
        public bool TrySaveInput(string input)
        {
            try { value = ToFloat(input); }
            catch
            {
                isCorrect = false;
                OnValueChanged?.Invoke(value);
                return false;
            }
            isCorrect = ValidateInput(value);
            OnValueChanged?.Invoke(value);
            return isCorrect;
        }
        /// <summary>
        /// Вызывается при изменении параметров обработки
        /// </summary>
        /// <param name="info"></param>
        public virtual void OnProcessingInfoChanged(ProcessingInfo? info) { }
        private static float ToFloat(string input) => CustomMath.ConvertToFloat(input);
        public Parameter() { }
        public Parameter(float defaultValue)
        {
            this.DefaultValue = defaultValue;
        }
    }
}
