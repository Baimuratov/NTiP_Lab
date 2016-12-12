using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <exception cref="System.ArgumentException"></exception>
        public double HoursInAir
        {
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Значение не может быть отрицательным");
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
