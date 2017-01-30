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
    public partial class EditTransportForm : Form
    {
        /// <summary>
        /// Форма, содержащая список в который добавляется объект реализующий ITransport
        /// </summary>
        private MainForm _parent;

        private int _transportIndex;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.AddTransportForm
        /// </summary>
        /// <param name="parentForm">Форма, содержащая список в который добавляется объект реализующий ITransport</param>
        public EditTransportForm(MainForm parentForm, int transportIndex)
        {
            InitializeComponent();
            _parent = parentForm;
            _transportIndex = transportIndex;
            if (_transportIndex < _parent.TransportList.Count)
            {
                transportControl1.Object = (Transport)_parent.TransportList[_transportIndex];
            }
            transportControl1.ReadOnly = false;
        }

        /// <summary>
        /// Добавляет в список главной формы объект выбранного типа с введёнными значениями свойств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _okButton_Click(object sender, EventArgs e)
        {
            /*ITransport someVehicles;
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
            }*/
            Transport transport = transportControl1.Object;
            if (transport == null)
            {
                return;
            }
            if (_transportIndex == _parent.TransportList.Count)
            {
                _parent.TransportList.Add(transport);
            }
            else
            {
                _parent.TransportList[_transportIndex] = transport;
            }
            _parent.DocumentChanged = true;
            // Добавление символа "*" в заголовок главной формы, показывающего что документ был изменён
            _parent.Text = Regex.Replace(_parent.Text, @".\z", match => match.Value == "*" ? match.Value : match.Value + "*");
            Close();
        }
    }
}
