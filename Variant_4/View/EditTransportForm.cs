using System;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма редактирования объекта типа Transport, который является 
    /// или новым объектом добавляемым в список TransportList главной формы, 
    /// или изменяемым объектом из этого списка
    /// </summary>
    public partial class EditTransportForm : Form
    {
        /// <summary>
        /// Форма, содержащая список где будет добавлен/изменён объект
        /// </summary>
        private readonly MainForm _parent;

        /// <summary>
        /// Индекс редактируемого объекта в списке главной формы
        /// </summary>
        private readonly int _transportIndex;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.EditTransportForm
        /// </summary>
        /// <param name="parentForm">Форма, содержащая список где будет добавлен/изменён объект типа Transport</param>
        /// <param name="transportIndex">Индекс редактируемого объекта в списке главной формы</param>
        public EditTransportForm(MainForm parentForm, int transportIndex)
        {
            InitializeComponent();
            _parent = parentForm;
            _transportIndex = transportIndex;
            if (_transportIndex < _parent.TransportList.Count)
            {
                _transportControl.Object = (Transport)_parent.TransportList[_transportIndex];
            }
            _transportControl.ReadOnly = false;
        }

        /// <summary>
        /// Заносит в список главной формы объект выбранного типа с введёнными значениями свойств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _okButton_Click(object sender, EventArgs e)
        {
            Transport transport = _transportControl.Object;
            // transport будет равен null в случае неправильных данных в текстовых полях
            if (transport == null)
            {
                return;
            }
            // Индекс равный Count - это индекс следующий после индекса последнего элемента,
            // такое значение подразумевает добавление нового элемента в конец списка
            if (_transportIndex == _parent.TransportList.Count)
            {
                _parent.TransportList.Add(transport);
                _parent.DocumentChanged = true;
            }
            else
            {
                // Проверка изменённости объекта нужна потому что кнопка "Ok" может быть нажата и при неизменных данных
                if (_parent.TransportList[_transportIndex] != transport)
                {
                    _parent.TransportList[_transportIndex] = transport;
                    _parent.DocumentChanged = true;
                }
            }
            Close();
        }
    }
}
