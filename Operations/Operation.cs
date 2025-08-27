using ProcessingTimeCalc.Operations.Collections;
using ProcessingTimeCalc.Operations.Parameters;
using ProcessingTimeCalc.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Operations
{
    /// <summary>
    /// Используемая операция
    /// </summary>
    public abstract class Operation
    {
        public abstract string Name { get; }
        /// <summary>
        /// Используемые параметры
        /// </summary>
        public IReadOnlyList<Parameter> Parameters
        {
            get
            {
                parameters ??= GetParameters();
                return parameters;
            }
        }
        private List<Parameter>? parameters = null;
        /// <summary>
        /// Используемые инструменты
        /// </summary>
        public IReadOnlyList<ToolType> Tools
        {
            get
            {
                tools ??= GetTools();
                return tools!;
            }

        }
        private List<ToolType>? tools = null;

        /// <summary>
        /// Создать новый список инструментов
        /// </summary>
        /// <returns></returns>
        protected abstract List<ToolType> GetTools();
        /// <summary>
        /// Создать новый список параметров
        /// </summary>
        /// <returns></returns>
        protected abstract List<Parameter> GetParameters();
        /// <summary>
        /// Расчет времени, учитывающий все параметры
        /// </summary>
        /// <returns>Время в секундах</returns>
        public abstract float CalculateTime();
        /// <summary>
        /// Расчет времени по формуле, использующей основные параметры
        /// </summary>
        /// <param name="processingLength">Длина обработки, мм</param>
        /// <param name="pitch">Подача, мм/мин</param>
        /// <returns>Время в секундах</returns>
        protected static float CalculateTimeByBaseParameters(float processingLength, float pitch)
        {
            float min = (processingLength) / (pitch);
            return min * 60;
        }
        /// <summary>
        /// Метод вызывается при изменении данных об обработке
        /// </summary>
        /// <param name="info"></param>
        public virtual void OnProcessingInfoChanged(ProcessingInfo? info) { }

        public Operation()
        {

        }
    }
}
