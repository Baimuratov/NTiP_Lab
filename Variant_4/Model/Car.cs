using System;

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
        /// <exception cref="ArgumentException"></exception>
        public double DroveKilometers
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
