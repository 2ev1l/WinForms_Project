using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations.Collections
{
    /// <summary>
    /// Набор данных для использования в Drop Down
    /// </summary>
    public abstract class Collection
    {
        /// <summary>
        /// Вызывается при изменении текущего значения
        /// </summary>
        public Action<object>? OnValueChanged;
        /// <summary>
        /// Название коллекции
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Список данных для Drop Down
        /// </summary>
        public object DataSource
        {
            get
            {
                dataSource ??= GetData();
                return dataSource!;
            }
        }
        private object? dataSource = null;
        /// <summary>
        /// Название свойства для отображения в GUI
        /// </summary>
        public abstract string DisplayMember { get; }
        /// <summary>
        /// Операция, в которой используется коллекция
        /// </summary>
        protected Operation Operation { get; }
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public abstract object DefaultValue { get; }
        /// <summary>
        /// Текущее значение
        /// </summary>
        public object? CurrentValue => currentValue;
        private object? currentValue = null;

        /// <summary>
        /// Установить новое текущее значение
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            currentValue = value;
            OnValueChanged?.Invoke(currentValue);
        }
        /// <summary>
        /// Получить новые данные, используемые в коллекции
        /// </summary>
        /// <returns></returns>
        protected abstract object GetData();
        public Collection(Operation operation)
        {
            this.Operation = operation;
        }
    }
}
