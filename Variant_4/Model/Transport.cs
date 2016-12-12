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
        private double _specificFC;
        
        /// <summary>
        /// Возвращает или задаёт удельный расход топлива. Единица измерения зависит от вида транспорта
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        public double SpecificFuelConsumption
        {
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Значение не может быть отрицательным");
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
