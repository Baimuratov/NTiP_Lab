using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Helicopter
    /// </summary>
    [TestFixture]
    public class HelicopterTest
    {
        /// <summary>
        /// Тестирует свойство HoursInAir
        /// </summary>
        /// <param name="hoursInAir">значение свойства HoursInAir</param>
        [Test]
        [TestCase(0, TestName = "Тестирование HoursInAir при присваивании 0")]
        [TestCase(1, TestName = "Тестирование HoursInAir при присваивании 1")]
        [TestCase(double.MaxValue - 1, TestName = "Тестирование HoursInAir при присваивании MaxValue - 1")]
        [TestCase(double.MaxValue, TestName = "Тестирование HoursInAir при присваивании MaxValue")]

        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Тестирование HoursInAir при присваивании -1")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Тестирование HoursInAir при присваивании минимально допустимого вещественного числа")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "Тестирование HoursInAir при присваивании 'Note a number'")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование HoursInAir при присваивании положительного бесконечного значения")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование HoursInAir при присваивании отрицатльного бесконечного значения")]
        public void HoursInAirTest(double hoursInAir)
        {
            var helicopter = new Helicopter();
            helicopter.HoursInAir = hoursInAir;
        }
    }
}
