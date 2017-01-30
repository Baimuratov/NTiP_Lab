using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class TransportControl : UserControl
    {
        private Validation _validation;
        private bool _readOnly;

        public Transport Object
        {
            set
            {
                if (value == null)
                {
                    _droveKilometersTextBox.Text = string.Empty;
                    _hoursInAirTextBox.Text = string.Empty;
                    _specificFuelConsumptionTextBox.Text = string.Empty;
                    _carRadioButton.Checked = true;  
                }
                else
                {
                    if (value.GetType() == typeof(Car))
                    {
                        Car auto = (Car)value;
                        _droveKilometersTextBox.Text = auto.DroveKilometers.ToString();
                        _carRadioButton.Checked = true;
                    }
                    else
                    {
                        Helicopter heli = (Helicopter)value;
                        _hoursInAirTextBox.Text = heli.HoursInAir.ToString();
                        _helicopterRadioButton.Checked = true;
                    }
                    _specificFuelConsumptionTextBox.Text = value.SpecificFuelConsumption.ToString();
                }
            }
            get
            {
                if (Application.ProductName != "View")
                {
                    return null;
                }
                /*if ((_carRadioButton.Checked || _helicopterRadioButton.Checked) == false)
                {
                    return null;
                }*/
                Transport transport;
                if (_carRadioButton.Checked)
                {
                    Car auto = new Car();
                    if (!WriteProperty(_droveKilometersTextBox.Text, "Drove kilometers", value => auto.DroveKilometers = value))
                    {
                        return null;
                    }
                    transport = auto;
                }
                else
                {
                    Helicopter heli = new Helicopter();
                    if (!WriteProperty(_hoursInAirTextBox.Text, "Hours in air", value => heli.HoursInAir = value))
                    {
                        return null;
                    }
                    transport = heli;
                }
                if (!WriteProperty(_specificFuelConsumptionTextBox.Text, "Specific fuel consumption", value => transport.SpecificFuelConsumption = value))
                {
                    return null;
                }
                else
                {
                    return transport;
                }
            }
        }

        public bool ReadOnly
        {
            set
            {
                if (value == true)
                {
                    _specificFuelConsumptionTextBox.ReadOnly = true;
                    _droveKilometersTextBox.ReadOnly = true;
                    _hoursInAirTextBox.ReadOnly = true;

                    _carRadioButton.Enabled = false;
                    _helicopterRadioButton.Enabled = false;
                    _randomDataButton.Enabled = false;
                }
                else
                {
                    _specificFuelConsumptionTextBox.ReadOnly = false;
                    _droveKilometersTextBox.ReadOnly = false;
                    _hoursInAirTextBox.ReadOnly = false;

                    _carRadioButton.Enabled = true;
                    _helicopterRadioButton.Enabled = true;
                    _randomDataButton.Enabled = true;
                }
                _readOnly = value;
            }
            get
            {
                return _readOnly;
            }
        }

        public TransportControl()
        {
            InitializeComponent();
            _validation = new Validation();
            #if !DEBUG
            _randomDataButton.Visible = false;
            #endif
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства SpecificFuelConsumption
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _specificFuelConsumptionTextBox_TextChanged(object sender, EventArgs e)
        {
            // если текстовое поле изменено пользователем
            if (_specificFuelConsumptionTextBox.Modified)
            {
                // выполнить фильтрацию текста, оставив только символы
                // представляющие натуральное или дробное число
                _validation.ValidateText(ref _specificFuelConsumptionTextBox);
            }
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства DroveKilometers
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _droveKilometersTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_droveKilometersTextBox.Modified)
            {
                _validation.ValidateText(ref _droveKilometersTextBox);
            }
        }

        /// <summary>
        /// Проверяет допустимость значения в поле ввода свойства HoursInAir
        /// после каждого изменения этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _hoursInAirTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_hoursInAirTextBox.Modified)
            {
                _validation.ValidateText(ref _hoursInAirTextBox);
            }
        }

        /// <summary>
        /// Включает или выключает поле ввода свойства присущего только типу Car, 
        /// когда изменяется состояние переключателя выбора Car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _carRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_carRadioButton.Checked)
            {
                _droveKilometersTextBox.Enabled = true;
            }
            else
            {
                _droveKilometersTextBox.Enabled = false;
                if (ReadOnly == true)
                {
                    _droveKilometersTextBox.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Включает или выключает поле ввода свойства присущего только типу Helicopter, 
        /// когда изменяется состояние переключателя выбора Helicopter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _helicopterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_helicopterRadioButton.Checked)
            {
                _hoursInAirTextBox.Enabled = true;
            }
            else
            {
                _hoursInAirTextBox.Enabled = false;
                if (ReadOnly == true)
                {
                    _hoursInAirTextBox.Text = string.Empty;
                }
            }
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

        private void _randomDataButton_Click(object sender, EventArgs e)
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
    }
}
