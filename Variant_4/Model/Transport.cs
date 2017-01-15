using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Содержит реализацию свойства удельный расход топлива для некоторого типа транспортного средства
    /// </summary>
    [Serializable]
    abstract public class Transport : ITransport
    {
        /// <summary>
        /// Удельный расход топлива. Единица измерения зависит от вида транспорта
        /// </summary>
        private double _specificFC;

        /// <summary>
        /// Возвращает или задаёт удельный расход топлива. Единица измерения зависит от вида транспорта
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double SpecificFuelConsumption
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Значение не может быть отрицательным");
                }
                if (double.IsNaN(value))
                {
                    throw new ArgumentException("Значение не может быть 'Not a number'");
                }
                if (double.IsInfinity(value))
                {
                    throw new ArgumentException("Значение не может быть бесконечностью");
                }
                else
                {
                    _specificFC = value;
                }  
            }
            get
            {
                return _specificFC;
            }
        }

        /// <summary>
        /// Возвращает объём расходованного топлива
        /// </summary>
        abstract public double FuelConsumption { get; }
    }
}
