using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Model;
using System.Reflection;

namespace View
{
    /// <summary>
    /// Форма добавления объекта реализующего интерфейс ITransport
    /// в список TransportList главной формы
    /// </summary>
    public partial class AddTransportForm : ValidationForm
    {
        /// <summary>
        /// Форма, содержащая список в который добавляется объект реализующий ITransport
        /// </summary>
        private MainForm _parent;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.AddTransportForm
        /// </summary>
        /// <param name="parentForm">Форма, содержащая список в который добавляется объект реализующий ITransport</param>
        public AddTransportForm(MainForm parentForm)
        {
            InitializeComponent();
            _parent = parentForm;
            #if !DEBUG
            _randomDataButton.Visible = false;
            #endif
        }

        /// <summary>
        /// Включает или выключает поле ввода свойства присущего только типу Car, 
        /// когда изменяется состояние переключателя выбора Car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_carRadioButton.Checked)
            {
                _droveKilometersTextBox.Enabled = true;
            }
            else
            {
                _droveKilometersTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// Включает или выключает поле ввода свойства присущего только типу Helicopter, 
        /// когда изменяется состояние переключателя выбора Helicopter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helicopterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_helicopterRadioButton.Checked)
            {
                _hoursInAirTextBox.Enabled = true;
            }
            else
            {
                _hoursInAirTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства SpecificFuelConsumption
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specificFuelConsumptionTextBox_TextChanged(object sender, EventArgs e)
        {
            // если текстовое поле изменено пользователем
            if (_specificFuelConsumptionTextBox.Modified)
            {
                // выполнить фильтрацию текста, оставив только символы
                // представляющие натуральное или дробное число
                ValidateText(ref _specificFuelConsumptionTextBox);
            }
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства DroveKilometers
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void droveKilometersTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_droveKilometersTextBox.Modified)
            {
                ValidateText(ref _droveKilometersTextBox);
            }
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства HoursInAir
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hoursInAirTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_hoursInAirTextBox.Modified)
            {
                ValidateText(ref _hoursInAirTextBox);
            }
        }

        /// <summary>
        /// Генерирует случайные допустимые значения в текстовых полях (используется для отладки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomDataButton_Click(object sender, EventArgs e)
        {
            Random randomData = new Random();
            _specificFuelConsumptionTextBox.Text = Convert.ToString(randomData.NextDouble() * 100);
            if (_droveKilometersTextBox.Enabled)
            {
                _droveKilometersTextBox.Text = Convert.ToString(randomData.NextDouble() * 100);
            }
            else
            {
                _hoursInAirTextBox.Text = Convert.ToString(randomData.NextDouble() * 10);
            }
        }

        /// <summary>
        /// Добавляет в список главной формы объект выбранного типа с введёнными значениями свойств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            ITransport someVehicles;
            if (_carRadioButton.Checked)
            {
                Car auto = new Car();
                if (!WriteProperty(_droveKilometersTextBox.Text, "Drove kilometers", value => auto.DroveKilometers = value))
                {
                    return;
                }
                someVehicles = auto;
            }
            else
            {
                Helicopter heli = new Helicopter();
                if (!WriteProperty(_hoursInAirTextBox.Text, "Hours in air", value => heli.HoursInAir = value))
                {
                    return;
                }
                someVehicles = heli;
            }
            if (!WriteProperty(_specificFuelConsumptionTextBox.Text, "Specific fuel consumption", value => someVehicles.SpecificFuelConsumption = value))
            {
                return;
            }
            _parent.TransportList.Add(someVehicles);

            _parent.DocumentChanged = true;
            // Добавление символа "*" в заголовок главной формы, показывающего что документ был изменён
            _parent.Text = Regex.Replace(_parent.Text, @".\z", match => match.Value == "*" ? match.Value : match.Value + "*");
            Close();
        }

        /// <summary>
        /// Записывает свойство типа double
        /// </summary>
        /// <param name="writingValue">Строковое представление присваиваемого значения</param>
        /// <param name="propertyName">Имя записываемого свойства</param>
        /// <param name="setFunction">Функция, вызывающая метод доступа set свойства</param>
        /// <returns>true если свойству присвоено значение, иначе false</returns>
        bool WriteProperty(string writingValue, string propertyName, Action<double> setFunction)
        {
            try 
            {
                setFunction(Convert.ToDouble(writingValue));
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(propertyName + " value must be a positive number");
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show(propertyName + " value has caused an overflow");
                return false;
            }
        }
    }
}
