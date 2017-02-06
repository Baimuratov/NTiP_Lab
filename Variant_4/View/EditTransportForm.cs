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

        /// <summary>
        /// 
        /// </summary>
        private int _transportIndex;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.EditTransportForm
        /// </summary>
        /// <param name="parentForm">Форма, содержащая список в который добавляется объект реализующий ITransport</param>
        /// <param name="transportIndex">Индекс редактируемого объекта в списке главной формы</param>
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
        /// Заносит в список главной формы объект выбранного типа с введёнными значениями свойств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _okButton_Click(object sender, EventArgs e)
        {
            Transport transport = transportControl1.Object;
            if (transport == null)
            {
                return;
            }

            if (_transportIndex == _parent.TransportList.Count)
            {
                _parent.TransportList.Add(transport);
                _parent.DocumentChanged = true;
            }
            else
            {
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
