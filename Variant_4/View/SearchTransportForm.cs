using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма поиска объектов в списке TransportList главной формы
    /// </summary>
    public partial class SearchTransportForm : Form
    {
        /// <summary>
        /// Форма, содержащая список в котором проводится поиск
        /// </summary>
        private MainForm _parent;

        /// <summary>
        /// Инкапсулирует метод, оставляющий в тексте только те символы, которые представляют вещественное число
        /// </summary>
        private DoubleFilter _filter;

        /// <summary>
        /// Возвращает или задаёт список результатов поиска
        /// </summary>
        public List<ITransport> ResultsList { set; get; }

        /// <summary>
        /// Используется для привязки ResultsList к элементу управления _resultsGridView
        /// </summary>
        private BindingSource _bindingResultsList;

        // Следующие массивы используются при поиске
        // для циклического обращения к свойствам элементов управления
        // и к свойствам объекта из списка TransportList
        
        /// <summary>
        /// Копирует значения свойств Checked элементов управления CheckBox,
        /// показывает какие свойства были выбраны для поиска
        /// </summary>
        private bool[] _checkedProperties = new bool[2];
        
        /// <summary>
        /// Копирует значения свойств SelectedIndex элементов управления ComboBox,
        /// содержит выбранные операции сравнения
        /// </summary>
        private int[] _searchTerms = new int[2];

        /// <summary>
        /// Содержит конвертированные в double
        /// значения свойств Text элементов управления TextBox,
        /// представляет заданные для поиска значения
        /// </summary>
        private double[] _searchValues = new double[2];

        /// <summary>
        /// Копирует значения свойств объекта, проверяемого на соответствие условиям поиска.
        /// Копируемые свойства являются общими для всех объектов реализующих ITransport
        /// </summary>
        private double[] _transportProperties = new double[2];

        /// <summary>
        /// Инициализирует новый экземпляр класса View.SearchTransportForm
        /// </summary>
        /// <param name="parentForm">Форма, содержащая список 
        /// объектов реализующих ITransport, в котором проводится поиск</param>
        public SearchTransportForm(MainForm parentForm)
        {
            InitializeComponent();
            
            _parent = parentForm;

            ResultsList = new List<ITransport>();
            _bindingResultsList = new BindingSource(this, "ResultsList");
            _resultsGridView.DataSource = _bindingResultsList;

            _filter = new DoubleFilter();

            _specificFuelConsumptionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _fuelConsumptionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _specificFuelConsumptionComboBox.SelectedItem = "=";
            _fuelConsumptionComboBox.SelectedItem = "=";
        }

        /// <summary>
        /// Выполняет поиск объектов, соответствующих заданным на форме
        /// условиям поиска, в списке главной формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            // Если поле отмечено, то записать его значение в массив _searchValues
            if (_specificFuelConsumptionCheckBox.Checked)
            {
                _checkedProperties[0] = true;
                if (!WriteDouble(ref _searchValues[0], _specificFuelConsumptionTextBox.Text, "Specific fuel consumption"))
                {
                    return;
                }
            }
            if (_fuelConsumptionCheckBox.Checked)
            {
                _checkedProperties[1] = true;
                if (!WriteDouble(ref _searchValues[1], _fuelConsumptionTextBox.Text, "Fuel consumption"))
                {
                    return;
                }
            }

            _searchTerms[0] = _specificFuelConsumptionComboBox.SelectedIndex;
            _searchTerms[1] = _fuelConsumptionComboBox.SelectedIndex;

            ResultsList.RemoveAll(transport => true);
            ResultsList.AddRange(_parent.TransportList.FindAll(Select));
            _bindingResultsList.ResetBindings(true);

            if (ResultsList.Count == 0)
            {
                _notFoundLabel.Visible = true;
            }
            else
            {
                _notFoundLabel.Visible = false;
            }
        }

        /// <summary>
        /// Присваивает переменной типа double значение конвертированного текста,
        /// обрабатывая возможные исключения формата и переполнения
        /// </summary>
        /// <param name="variable">Переменная, которой присваивается значение</param>
        /// <param name="writingValue">Строковое представление присваиваемого значения</param>
        /// <param name="showingName">Имя переменной отображаемое в окне при возникновении исключений</param>
        /// <returns>true если переменной присвоено значение, иначе false</returns>
        bool WriteDouble(ref double variable, string writingValue, string showingName)
        {
            if (writingValue == string.Empty)
            {
                MessageBox.Show(showingName + " value is empty");
                return false;
            }
            try
            {
                variable = Convert.ToDouble(writingValue);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(showingName + " value must be a positive number");
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show(showingName + " value has caused an overflow");
                return false;
            }
        }

        /// <summary>
        /// Проверяет соответствие объекта условиям поиска
        /// </summary>
        /// <param name="transport">Проверяемый объект</param>
        /// <returns>true - объект соответствует критериям поиска, иначе false</returns>
        public bool Select(ITransport transport)
        {
            bool match = true;
            _transportProperties[0] = transport.SpecificFuelConsumption;
            _transportProperties[1] = transport.FuelConsumption;
            for (int i = 0; i < 2; i++)
            {
                if (!_checkedProperties[i])
                {
                    continue;
                }

                switch (_searchTerms[i])
                {
                    case 0:
                        match &= _transportProperties[i] < _searchValues[i];
                        break;
                    case 1:
                        match &= _transportProperties[i] <= _searchValues[i];
                        break;
                    case 2:
                        match &= _transportProperties[i] == _searchValues[i];
                        break;
                    case 3:
                        match &= _transportProperties[i] >= _searchValues[i];
                        break;
                    case 4:
                        match &= _transportProperties[i] > _searchValues[i];
                        break;
                }
                if (!match)
                {
                    return false;
                }
            }
            return match;
        }

        /// <summary>
        /// Когда изменяется состояние флажка поиска по свойству SpecificFuelConsumption,
        /// включает или выключает элементы управления, 
        /// задающие условие выборки по данному свойству
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specificFuelConsumptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_specificFuelConsumptionCheckBox.Checked)
            {
                _specificFuelConsumptionComboBox.Enabled = true;
                _specificFuelConsumptionTextBox.Enabled = true;
                _searchButton.Enabled = true;
            }
            else
            {
                _specificFuelConsumptionComboBox.Enabled = false;
                _specificFuelConsumptionTextBox.Enabled = false;
                if (!_fuelConsumptionCheckBox.Checked)
                {
                    _searchButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Когда изменяется состояние флажка поиска по свойству FuelConsumption,
        /// включает или выключает элементы управления, 
        /// задающие условие выборки по данному свойству
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fuelConsumptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_fuelConsumptionCheckBox.Checked)
            {
                _fuelConsumptionComboBox.Enabled = true;
                _fuelConsumptionTextBox.Enabled = true;
                _searchButton.Enabled = true;
            }
            else
            {
                _fuelConsumptionComboBox.Enabled = false;
                _fuelConsumptionTextBox.Enabled = false;
                if (!_specificFuelConsumptionCheckBox.Checked)
                {
                    _searchButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Проверяет допустимость данных 
        /// в поле ввода значения для поиска по свойству SpecificFuelConsumption 
        /// при каждом изменении этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specificFuelConsumptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_specificFuelConsumptionTextBox.Modified)
            {
                _filter.FilterText(ref _specificFuelConsumptionTextBox);
            }
        }

        /// <summary>
        /// Проверяет допустимость данных 
        /// в поле ввода значения для поиска по свойству FuelConsumption 
        /// при каждом изменении этого поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fuelConsumptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_fuelConsumptionTextBox.Modified)
            {
                _filter.FilterText(ref _fuelConsumptionTextBox);
            }
        }
    }
}
