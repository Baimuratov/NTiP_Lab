using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
        /// Список объектов типа Transport, в котором изменяется или добавляется объект
        /// </summary>
        private readonly List<ITransport> _transportList;

        /// <summary>
        /// Индекс редактируемого объекта в списке главной формы
        /// </summary>
        private readonly int _transportIndex;

        /// <summary>
        /// Возвращает или задаёт признак изменённости списка объектов типа Transport
        /// </summary>
        public bool TransportListChanged { set; get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса View.EditTransportForm
        /// </summary>
        /// <param name="transportList">Cписок где будет добавлен/изменён объект типа Transport</param>
        /// <param name="transportIndex">Индекс редактируемого объекта в списке</param>
        public EditTransportForm(List<ITransport> transportList, int transportIndex)
        {
            InitializeComponent();

            TransportListChanged = false;
            _transportList = transportList;
            _transportIndex = transportIndex;
            if (_transportIndex < _transportList.Count)
            {
                _transportControl.Object = (Transport)_transportList[_transportIndex];
            }
            _transportControl.ReadOnly = false;
        }

        /// <summary>
        /// Заносит в список объект выбранного типа с введёнными значениями свойств
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
            if (_transportIndex == _transportList.Count)
            {
                _transportList.Add(transport);
                TransportListChanged = true;
            }
            else
            {
                // Проверка изменённости объекта нужна потому что кнопка "Ok" может быть нажата и при неизменных данных
                if (_transportList[_transportIndex] != transport)
                {
                    _transportList[_transportIndex] = transport;
                    TransportListChanged = true;
                }
            }
            Close();
        }
    }
}
