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
    /// <summary>
    /// Элемент управления отражающий свойства объекта типа Transport
    /// </summary>
    public partial class TransportControl : UserControl
    {
        /// <summary>
        /// Инкапсулирует метод, оставляющий в тексте только те символы, которые представляют вещественное число
        /// </summary>
        private DoubleFilter _filter;
        
        /// <summary>
        /// Режим доступа к данным в текстовых полях: 
        /// true - только для чтения, false - разрешено редактирование
        /// </summary>
        private bool _readOnly;
        
        /// <summary>
        /// Возвращает или задаёт объект, чьи свойства отражает элемент управления. 
        /// Если текстовые поля содержат некорректные данные, то возвращается null
        /// </summary>
        public Transport Object
        {
            set
            {
                if (value == null)
                {
                    _droveKilometersTextBox.Text = string.Empty;
                    _hoursInAirTextBox.Text = string.Empty;
                    _specificFuelConsumptionTextBox.Text = string.Empty;
                    // Car - тип по умолчанию
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
                // При использовании данного элемента управления в конструкторе форм
                // метод доступа get вызывается автоматически.
                // Он выполняет проверку данных в текстовых полях с выводом сообщений об ошибках.
                // Чтобы эти сообщения не появлялись при работе в конструкторе форм,
                // проверка достижима только если выполняется данный проект
                if (Application.ProductName != "View")
                {
                    return null;
                }
                Transport transport;
                if (_carRadioButton.Checked)
                {
                    Car auto = new Car();
                    // Попытка записать в свойство данные из текстового поля.
                    // При неправильных данных метод WriteProperty выведет окно с описанием ошибки
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
                // Проверка значения свойства FuelConsumption,
                // которое не задаётся непосредственно, а
                // вычисляется на основе записанных свойств
                try
                {
                    double test = transport.FuelConsumption;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The entered property values is incorrect because of overflow when calculating the fuel consumption");
                    return null;
                }
                return transport;
            }
        }

        /// <summary>
        /// Возвращает или задаёт режим доступа к данным в текстовых полях: 
        /// true - только для чтения, false - разрешено редактирование
        /// </summary>
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

        /// <summary>
        /// Инициализирует новый экземпляр класса View.TransportControl
        /// </summary>
        public TransportControl()
        {
            InitializeComponent();
            _filter = new DoubleFilter();
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
            // Если текстовое поле изменено пользователем
            if (_specificFuelConsumptionTextBox.Modified)
            {
                // выполнить фильтрацию текста, оставив только символы
                // представляющие натуральное или дробное число
                _filter.FilterText(ref _specificFuelConsumptionTextBox); 
            }
            // Отобразить FuelConsumption рассчитаное по новому значению свойства
            //CalculateFuelConsumption();
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
                _filter.FilterText(ref _droveKilometersTextBox);
            }
            //CalculateFuelConsumption();
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
                _filter.FilterText(ref _hoursInAirTextBox);
            }
            //CalculateFuelConsumption();
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
            CalculateFuelConsumption();
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
            CalculateFuelConsumption();
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

        /// <summary>
        /// Генерирует в текстовых полях случайные допустимые данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Отображает в текстовом поле значение свойства FuelConsumption, 
        /// которое доступно только для чтения и 
        /// вычисляется на основе свойств задаваемых в данном элементе управления
        /// </summary>
        private void CalculateFuelConsumption()
        {
            Transport transport;
            try
            {
                if (_carRadioButton.Checked)
                {
                    Car auto = new Car();
                    auto.DroveKilometers = Convert.ToDouble(_droveKilometersTextBox.Text);
                    transport = auto;
                }
                else
                {
                    Helicopter heli = new Helicopter();
                    heli.HoursInAir = Convert.ToDouble(_hoursInAirTextBox.Text);
                    transport = heli;
                }
                transport.SpecificFuelConsumption = Convert.ToDouble(_specificFuelConsumptionTextBox.Text);
            }
            catch (Exception)
            {
                // Содержащиеся в текстовых полях значения свойств некорректны,
                // FuelConsumption вычислить по ним невозможно
                _fuelConsumptionTextBox.Text = string.Empty;
                return;
            }
            try
            {
                _fuelConsumptionTextBox.Text = transport.FuelConsumption.ToString();
            }
            catch (OverflowException)
            {
                _fuelConsumptionTextBox.Text = "overflow";
            }
        }
    }
}
