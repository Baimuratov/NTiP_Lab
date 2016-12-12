using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleLoader
{
    class Program
    {
        static void Main()
        {
            ITransport someVehicles;
            Car auto = new Car();
            Helicopter heli = new Helicopter();
            int keyCode;

            Console.WriteLine("Укажите тип транспортного средства: а - автомобиль, в - вертолёт.");
            Console.WriteLine("Нажмите Esc для выхода");
            while (true)
            {
                keyCode = Console.ReadKey().KeyChar;
                switch (keyCode)
                {
                    case (int)ConsoleKey.Escape:
                        return;
                    case 'а':
                        Console.WriteLine("\nВведите числовые параметры: при наличии дробной части в качестве разделителя используется запятая");
                        WriteProperty("Пройденный путь км", (value) => auto.DroveKilometers = value);

                        someVehicles = auto;
                        WriteProperty("Средний расход топлива л/100 км", (value) => someVehicles.SpecificFuelConsumption = value);
                        break;
                    case 'в':
                        Console.WriteLine("\nВведите числовые параметры: при наличии дробной части в качестве разделителя используется запятая");
                        WriteProperty("Время полёта в часах", (value) => heli.HoursInAir = value);

                        someVehicles = heli;
                        WriteProperty("Средний расход топлива л/ч", (value) => someVehicles.SpecificFuelConsumption = value);
                        break;
                    default:
                        Console.WriteLine("\nНеверный символ");
                        continue;
                }
                Console.WriteLine("Расход топлива равен {0} л", someVehicles.FuelConsumption);
                
                Console.WriteLine("\nУкажите тип транспортного средства: а - автомобиль, в - вертолёт.");
                Console.WriteLine("Нажмите Esc для выхода");
            }
        }

        /// <summary>
        /// Присваивает введённое пользователем значение свойству класса производного от Transport.
        /// Обрабатывает возможные исключения формата и аргумента.
        /// </summary>
        /// <param name="message">Отображаемая пользователю строка, содержащая сведения о записываемом свойстве</param>
        /// <param name="setFunction">Функция, вызывающая метод доступа set свойства</param>
        static void WriteProperty(string message, Action<double> setFunction)
        {
            string errorMessage = "Значение должно быть положительным числом ";
            while (true)
            {
                try
                {
                    Console.Write(message+" ");
                    setFunction(Convert.ToDouble(Console.ReadLine()));
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(errorMessage);
                }
                catch (FormatException)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

    }
}
