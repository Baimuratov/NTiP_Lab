using System;

namespace Model
{
    /// <summary>
    /// Задаёт свойства, необходимые для определения объёма топлива, расходуемого транспортным средством
    /// </summary>
    public interface ITransport
    {
        /// <summary>
        /// Возвращает или задаёт удельный расход топлива. Единица измерения зависит от вида транспорта
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        double SpecificFuelConsumption { set; get; }
        
        /// <summary>
        /// Возвращает объём расходованного топлива
        /// </summary>
        double FuelConsumption { get; }
    }
}
