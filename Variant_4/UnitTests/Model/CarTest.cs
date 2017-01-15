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
    /// Набор тестов для класса Car
    /// </summary>
    [TestFixture]
    public class CarTest
    {
        /// <summary>
        /// Тестирует свойство DroveKilometers
        /// </summary>
        /// <param name="droveKilometers">значение свойства DroveKilometers</param>
        [Test]
        [TestCase(0, TestName = "Тестирование DroveKilometers при присваивании 0")]
        [TestCase(1, TestName = "Тестирование DroveKilometers при присваивании 1")]
        [TestCase(double.MaxValue - 1, TestName = "Тестирование DroveKilometers при присваивании MaxValue - 1")]
        [TestCase(double.MaxValue, TestName = "Тестирование DroveKilometers при присваивании MaxValue")]

        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Тестирование DroveKilometers при присваивании -1")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Тестирование DroveKilometers при присваивании минимально допустимого вещественного числа")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "Тестирование DroveKilometers при присваивании 'Note a number'")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование DroveKilometers при присваивании положительного бесконечного значения")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование DroveKilometers при присваивании отрицатльного бесконечного значения")]
        public void DroveKilometersTest(double droveKilometers)
        {
            var car = new Car();
            car.DroveKilometers = droveKilometers;
        }
    }
}
