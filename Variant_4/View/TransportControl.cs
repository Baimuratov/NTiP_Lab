using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class TransportControl : UserControl
    {
        private Validation _validation;

        public TransportControl()
        {
            InitializeComponent();
            _validation = new Validation();
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
            }
        }
    }
}
