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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;

namespace View
{
    /// <summary>
    /// Статус документа
    /// </summary>
    public enum DocumentStatus
    {
        /// <summary>
        /// Новый
        /// </summary>
        New,
        /// <summary>
        /// Связан с файлом
        /// </summary>
        HasFile,
        /// <summary>
        /// Документ отсутствует
        /// </summary>
        None
    }

    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Возвращает или задаёт список объектов реализующих интерфейс ITransport.
        /// Данный список отображается элементом управления _transportListGridView
        /// </summary>
        public List<ITransport> TransportList { set; get; }

        /// <summary>
        /// Используется для привязки TransportList к _transportListGridView
        /// </summary>
        private BindingSource _bindingTransportList;

        /// <summary>
        /// Статус документа приложения (данных в TransportList)
        /// </summary>
        private DocumentStatus _documentStatus;

        /// <summary>
        /// Используется для нумерации имён новых документов
        /// </summary>
        private int _newDocumentIndex;

        /// <summary>
        /// Показывает был ли изменён документ с момента создания, открытия или сохранения
        /// </summary>
        public bool DocumentChanged;

        /// <summary>
        /// Используется при сериализации или десериализации списка TransportList
        /// </summary>
        private BinaryFormatter _formatter;

        /// <summary>
        /// Поток связывающий приложение с файлом, в который производится запись документа или его чтение
        /// </summary>
        private FileStream _file;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            TransportList = new List<ITransport>();
            _bindingTransportList = new BindingSource(this, "TransportList");
            _transportListGridView.DataSource = _bindingTransportList;

            _documentStatus = DocumentStatus.New;
            _newDocumentIndex = 1;
            DocumentChanged = false;
            Text += " - New list1";

            _formatter = new BinaryFormatter();
            _file = null;
        }

        /// <summary>
        /// Создаёт и отображает форму добавления объекта в TransportList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            AddTransportForm addingForm = new AddTransportForm(this);
            addingForm.ShowDialog();
            _bindingTransportList.ResetBindings(true);
        }


        /// <summary>
        /// Создаёт и отображает форму поиска объектов в TransportList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchTransportForm searchForm = new SearchTransportForm(this);
            searchForm.ShowDialog();
        }

        /// <summary>
        /// Удаляет в TransportList объекты, ячейки свойств которых, выбраны в таблице _transportListGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (TransportList.Count == 0)
            {
                return;
            }
            DataGridViewSelectedCellCollection cells = _transportListGridView.SelectedCells;
            List<DataGridViewCell> newCells = new List<DataGridViewCell>();
            newCells.Add(cells[0]);
            // получение списка newCells, в котором все ячейки принадлежат разным строкам
            bool unique;
            for (int i = 1; i < cells.Count; i++)
            {
                // делаем предположение что cells[i] обладает индексом строки
                // не встречающимся у ячеек newCells
                unique = true;
                for (int j = 0; j < newCells.Count; j++)
                {
                    if (newCells[j].RowIndex == cells[i].RowIndex)
                    {
                        unique = false;
                        break;
                    }
                }
                if (unique)
                {
                    newCells.Add(cells[i]);
                }
            }

            foreach (DataGridViewCell cell in newCells)
            {
                TransportList[cell.RowIndex] = null;
            }
            int remoteObjectsCount = TransportList.RemoveAll(transport => transport == null);
            _bindingTransportList.ResetBindings(true);
            if (remoteObjectsCount > 0)
            {
                DocumentChanged = true;
                // Добавление в заголовок окна, символа, показывающего что документ был изменён
                Text = Regex.Replace(Text, @".\z", match => match.Value == "*" ? match.Value : match.Value + "*");
            }
        }

        /// <summary>
        /// Создаёт новый документ при нажатии кнопки "New" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DiscontinueCurrentDocument())
            {
                NewDocument();
            } 
        }

        /// <summary>
        /// Загружает документ из файла при нажатии кнопки "Open" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DiscontinueCurrentDocument())
            {
                LoadDocument();
            }
        }

        /// <summary>
        /// Сохраняет документ в файл связанный потоком с приложением. 
        /// При отсутствии потока (новый документ) предлагает задать имя файла для сохранения. 
        /// Вызывается нажатием кнопки "Save" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DocumentChanged)
            {
                SaveDocument();
            }
        }

        /// <summary>
        /// Сохраняет документ в файл с заданным именем при нажатии кнопки "Save as" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_documentStatus == DocumentStatus.HasFile)
            {
                // Документ принимается за новый, чтобы метод SaveDocument()
                // отобразил диалоговое окно задания имени сохраняемого файла.
                // Значение _documentStatus изменится на HasFile
                // только если будет выполнено сохранение
                _documentStatus = DocumentStatus.New;
                
                // Если сохранение в новый файл не выполнено
                // (выбрана "отмена" или не удалось создать файл),
                // то продолжить работу с прежним,
                // вернуть значение _documentStatus
                if (!SaveDocument())
                {
                    _documentStatus = DocumentStatus.HasFile;
                }
            }
            else
            {
                SaveDocument();
            }
        }


        /// <summary>
        /// Завершает работу с текущим документом при нажатии кнопки "Close" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DiscontinueCurrentDocument())
            {
                CloseDocument();
            }
        }

        /// <summary>
        /// Выводит диалоговое окно, запрашивающее сохранение изменений 
        /// в текущем документе перед его закрытием,
        /// а также подтверждение закрытия документа.
        /// </summary>
        /// <returns>true - прекратить работу с текущим документом; false - продолжить</returns>
        private bool DiscontinueCurrentDocument()
        {
            if (DocumentChanged)
            {
                switch (MessageBox.Show(string.Format("Save changes in {0}?", _documentStatus == DocumentStatus.New ? "New List" + Convert.ToString(_newDocumentIndex) : _file.Name), 
                    "", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        SaveDocument();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Создаёт новый документ
        /// </summary>
        private void NewDocument()
        {
            if (_file != null)
            {
                _file.Close();
                _file = null;
            }

            TransportList.RemoveAll(transport => true);
            _bindingTransportList.ResetBindings(true);

            if (_documentStatus == DocumentStatus.None)
            {
                EnableButtons();
            }
            _documentStatus = DocumentStatus.New;
            _newDocumentIndex++;
            DocumentChanged = false;
            Text = "Transport Browser - New list" + Convert.ToString(_newDocumentIndex);
        }

        /// <summary>
        /// Загружает документ из существующего файла
        /// </summary>
        private void LoadDocument()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream tempFile;
                List<ITransport> tempList;
                try
                {
                    tempFile = System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                    tempList = (List<ITransport>)_formatter.Deserialize(tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load file: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (_file != null)
                {
                    _file.Close();
                }
                _file = tempFile;
                // Смещение указателя в начало файла,
                // чтобы в случае сериализации происходила перезапись
                _file.Position = 0;

                TransportList.RemoveAll(transport => true);
                TransportList.AddRange(tempList);
                _bindingTransportList.ResetBindings(true);

                if (_documentStatus == DocumentStatus.None)
                {
                    EnableButtons();
                }
                _documentStatus = DocumentStatus.HasFile;
                DocumentChanged = false;
                Text = "Transport Browser - " + _file.Name;
            }
        }

        /// <summary>
        /// Сохраняет документ в существующий или новый файл
        /// </summary>
        /// <returns>true - если сохранение выполнено, иначе false</returns>
        private bool SaveDocument()
        {
            if (_documentStatus == DocumentStatus.New)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream tempFile;
                    try
                    {
                        tempFile = System.IO.File.Create(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not create a file: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (_file != null)
                    {
                        _file.Close();
                    }
                    _file = tempFile;
                    _documentStatus = DocumentStatus.HasFile;
                }
                else
                {
                    return false;
                }
            }
            _formatter.Serialize(_file, TransportList);
            // Смещение указателя в начало файла,
            // чтобы при повторном сохранении происходила перезапись
            _file.Position = 0;
            DocumentChanged = false;
            Text = "Transport Browser - " + _file.Name;
            return true;
        }

        /// <summary>
        /// Прекращает работу с текущим документом
        /// </summary>
        private void CloseDocument()
        {
            if (_file != null)
            {
                _file.Close();
                _file = null;
            }
            TransportList.RemoveAll(transport => true);
            _bindingTransportList.ResetBindings(true);

            _transportListGridView.Enabled = false;
            _addButton.Enabled = false;
            _removeButton.Enabled = false;
            _searchButton.Enabled = false;
            _saveToolStripMenuItem.Enabled = false;
            _saveAsToolStripMenuItem.Enabled = false;
            _closeToolStripMenuItem.Enabled = false;

            _documentStatus = DocumentStatus.None;
            DocumentChanged = false;
            Text = "Transport Browser";
        }

        /// <summary>
        /// Активирует кнопки, отключаемые в режиме "без документа"
        /// </summary>
        private void EnableButtons()
        {
            _transportListGridView.Enabled = true;
            _addButton.Enabled = true;
            _removeButton.Enabled = true;
            _searchButton.Enabled = true;
            _saveToolStripMenuItem.Enabled = true;
            _saveAsToolStripMenuItem.Enabled = true;
            _closeToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Перед закрытием главной формы при наличии изменений в документе 
        /// выводит диалог, запршаивающий их сохранение и подтверждение закрытия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DiscontinueCurrentDocument())
            {
                e.Cancel = true;
            }
        }
    }
}
