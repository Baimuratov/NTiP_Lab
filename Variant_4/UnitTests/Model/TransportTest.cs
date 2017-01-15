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
    /// Набор тестов для класса Transport
    /// </summary>
    [TestFixture]
    public class TransportTest
    {
        /// <summary>
        /// Тестирует свойство SpecificFuelConsumption
        /// </summary>
        /// <param name="specificFuelConsumption">значение свойства SpecificFuelConsumption</param>
        [Test]
        [TestCase(0, TestName = "Тестирование SpecificFuelConsumption при присваивании 0")]
        [TestCase(1, TestName = "Тестирование SpecificFuelConsumption при присваивании 1")]
        [TestCase(double.MaxValue - 1, TestName = "Тестирование SpecificFuelConsumption при присваивании MaxValue - 1")]
        [TestCase(double.MaxValue, TestName = "Тестирование SpecificFuelConsumption при присваивании MaxValue")]

        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Тестирование SpecificFuelConsumption при присваивании -1")]
        [TestCase(double.MinValue, ExpectedException = typeof(ArgumentException), TestName = "Тестирование SpecificFuelConsumption при присваивании минимально допустимого вещественного числа")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException), TestName = "Тестирование SpecificFuelConsumption при присваивании 'Note a number'")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование SpecificFuelConsumption при присваивании положительного бесконечного значения")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException), TestName = "Тестирование SpecificFuelConsumption при присваивании отрицатльного бесконечного значения")]
        public void SpecificFuelConsumptionTest(double specificFuelConsumption)
        {
            // Transport - абстрактный класс, содержащий реализацию свойства SpecificFuelConsumption.
            // Для тестирования этого свойства можно создать экземпляр любого
            // наследующего класса: Car или Helicopter
            Transport transport = new Car();
            transport.SpecificFuelConsumption = specificFuelConsumption;
        }
    }
}
