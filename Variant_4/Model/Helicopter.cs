using System;

namespace Model
{
    /// <summary>
    /// Содержит свойства вертолёта, достаточные для определения объёма топлива, расходуемого вертолётом
    /// </summary>
    [Serializable]
    public class Helicopter : Transport
    {
        /// <summary>
        /// Время полёта в часах
        /// </summary>
        private double _hoursInAir;

        /// <summary>
        /// Возвращает или задаёт время полёта в часах
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double HoursInAir
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
                    _hoursInAir = value;
                }
            }
            get
            {
                return _hoursInAir;
            }
        }
        /// <summary>
        /// Возвращает объём расходованного топлива
        /// </summary>
        public override double FuelConsumption
        {
            get
            {
                return _hoursInAir * SpecificFuelConsumption;
            }
        }
    }
}
