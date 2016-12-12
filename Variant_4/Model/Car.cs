using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Содержит свойства автомобиля, достаточные для определения объёма топлива, расходуемого автомобилем
    /// </summary>
    [Serializable]
    public class Car : Transport
    {
        /// <summary>
        /// Пройденный путь в км
        /// </summary>
        private double _droveKilometers;

        /// <summary>
        /// Возвращает или задаёт пройденный путь в км
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        public double DroveKilometers
        {
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Значение не может быть отрицательным");
                }
                else
                {
                    _droveKilometers = value;
                }
            }
            get
            {
                return _droveKilometers;
            }
        }

        /// <summary>
        /// Возвращает объём расходованного топлива
        /// </summary>
        public override double FuelConsumption
        {
            get
            {
                return _droveKilometers / 100 * SpecificFuelConsumption;
            }
        }
    }
}
