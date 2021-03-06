﻿using System;
using System.Collections.Generic;
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
        /// Список объектов реализующих интерфейс ITransport.
        /// Данный список отображается элементом управления _transportListGridView
        /// </summary>
        private readonly List<ITransport> _transportList;

        /// <summary>
        /// Используется для привязки TransportList к _transportListGridView
        /// </summary>
        private readonly BindingSource _bindingTransportList;

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
        private bool _documentChanged;

        /// <summary>
        /// Возвращает или задаёт признак изменённости документа
        /// </summary>
        public bool DocumentChanged
        {
            set
            {
                _documentChanged = value;
                if (value)
                {
                    // Добавление в заголовок окна, символа, показывающего что документ был изменён
                    Text = Regex.Replace(Text, @".\z", match => match.Value == "*" ? match.Value : match.Value + "*");
                }
            }
            get
            {
                return _documentChanged;
            }
        }

        /// <summary>
        /// Поток связывающий приложение с файлом, в который производится запись документа или его чтение
        /// </summary>
        private FileStream _file;

        /// <summary>
        /// Инициализирует новый экземпляр класса View.MainForm
        /// </summary>
        /// <param name="fileName">Имя файла открываемого в главной форме</param>
        public MainForm(string fileName)
        {
            InitializeComponent();

            _transportList = new List<ITransport>();
            _bindingTransportList = new BindingSource();
            _bindingTransportList.DataSource = _transportList;
            _transportListGridView.DataSource = _bindingTransportList;

            _documentStatus = DocumentStatus.New;
            Text += " - New list1";
            _newDocumentIndex = 1;
            DocumentChanged = false;

            _file = null;

            _transportControl.ReadOnly = true;

            if (fileName != string.Empty)
            {
                LoadDocument(fileName);
            }
        }

        /// <summary>
        /// Создаёт и отображает форму добавления объекта в TransportList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            EditTransportForm addingForm = new EditTransportForm(_transportList, _transportList.Count);
            addingForm.Text = "Add new transport";
            addingForm.ShowDialog();
            if (addingForm.TransportListChanged)
            {
                DocumentChanged = true;
                _bindingTransportList.ResetBindings(true);
            }
        }

        /// <summary>
        /// Создаёт и отображает форму изменения объекта в TransportList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _modifyButton_Click(object sender, EventArgs e)
        {
            if (_transportListGridView.CurrentCell != null)
            {
                EditTransportForm modifyForm = new EditTransportForm(_transportList, _transportListGridView.CurrentCell.RowIndex);
                modifyForm.Text = "Modify transport";
                modifyForm.ShowDialog();
                if (modifyForm.TransportListChanged)
                {
                    DocumentChanged = true;
                    _bindingTransportList.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Создаёт и отображает форму поиска объектов в TransportList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchTransportForm searchForm = new SearchTransportForm(_transportList);
            searchForm.ShowDialog();
        }

        /// <summary>
        /// Удаляет в TransportList объекты, ячейки свойств которых, выбраны в таблице _transportListGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (_transportList.Count == 0)
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
                _transportList[cell.RowIndex] = null;
            }
            int remoteObjectsCount = _transportList.RemoveAll(transport => transport == null);
            _bindingTransportList.ResetBindings(true);
            if (remoteObjectsCount > 0)
            {
                DocumentChanged = true;
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
            if (DiscontinueCurrentDocument() && openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadDocument(openFileDialog.FileName);
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
                // отобразил диалоговое окно задания имени сохраняемого файла
                _documentStatus = DocumentStatus.New;
                SaveDocument();
                _documentStatus = DocumentStatus.HasFile;
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
        /// а также подтверждение закрытия документа
        /// </summary>
        /// <returns>true - прекратить работу с текущим документом; false - продолжить</returns>
        private bool DiscontinueCurrentDocument()
        {
            if (DocumentChanged)
            {
                string documentName;
                if (_documentStatus == DocumentStatus.New)
                {
                    documentName = "New List" + _newDocumentIndex.ToString();
                }
                else
                {
                    documentName = _file.Name;
                }

                switch (MessageBox.Show("Save changes in " + documentName + "?", "", MessageBoxButtons.YesNoCancel))
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

            _transportList.RemoveAll(transport => true);
            _bindingTransportList.ResetBindings(true);
            _transportControl.Object = null;

            if (_documentStatus == DocumentStatus.None)
            {
                EnableButtons();
            }
            _documentStatus = DocumentStatus.New;
            _newDocumentIndex++;
            DocumentChanged = false;
            Text = "Transport Viewer - New list" + Convert.ToString(_newDocumentIndex);
        }

        /// <summary>
        /// Загружает документ из существующего файла
        /// </summary>
        /// <param name="fileName">Имя загружаемого файла</param>
        private void LoadDocument(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream tempFile;
            List<ITransport> tempList;
            try
            {
                tempFile = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
                tempList = (List<ITransport>)formatter.Deserialize(tempFile);
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

            _transportList.RemoveAll(transport => true);
            _transportList.AddRange(tempList);
            _bindingTransportList.ResetBindings(true);

            if (_documentStatus == DocumentStatus.None)
            {
                EnableButtons();
            }
            _documentStatus = DocumentStatus.HasFile;
            DocumentChanged = false;
            Text = "Transport Viewer - " + _file.Name;
        }

        /// <summary>
        /// Сохраняет документ в существующий или новый файл
        /// </summary>
        private void SaveDocument()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (_documentStatus == DocumentStatus.New)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream tempFile;
                    try
                    {
                        tempFile = File.Create(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not create a file: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
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
                    return;
                }
            }
            formatter.Serialize(_file, _transportList);
            // Смещение указателя в начало файла,
            // чтобы при повторном сохранении происходила перезапись
            _file.Position = 0;
            DocumentChanged = false;
            Text = "Transport Viewer - " + _file.Name;
            return;
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
            _transportList.RemoveAll(transport => true);
            _bindingTransportList.ResetBindings(true);
            _transportControl.Object = null;

            _transportListGridView.Enabled = false;
            _addButton.Enabled = false;
            _modifyButton.Enabled = false;
            _removeButton.Enabled = false;
            _searchButton.Enabled = false;
            _saveToolStripMenuItem.Enabled = false;
            _saveAsToolStripMenuItem.Enabled = false;
            _closeToolStripMenuItem.Enabled = false;

            _documentStatus = DocumentStatus.None;
            DocumentChanged = false;
            Text = "Transport Viewer";
        }

        /// <summary>
        /// Активирует кнопки, отключаемые в режиме "без документа"
        /// </summary>
        private void EnableButtons()
        {
            _transportListGridView.Enabled = true;
            _addButton.Enabled = true;
            _modifyButton.Enabled = true;
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

        /// <summary>
        /// При изменении выбора объекта в таблице _transportListGridView 
        /// отображает свойства выбранного объекта 
        /// в панели _transportControl и текстовом поле _fuelConsumptionTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _transportListGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (_transportListGridView.CurrentCell == null)
            {
                _transportControl.Object = null;
                _fuelConsumptionTextBox.Text = string.Empty;
            }
            else
            {
                _transportControl.Object = (Transport)_transportList[_transportListGridView.CurrentCell.RowIndex];
                _fuelConsumptionTextBox.Text = _transportList[_transportListGridView.CurrentCell.RowIndex].FuelConsumption.ToString();
            }
        }

        /// <summary>
        /// Завершает работу приложения при нажатии кнопки "Exit" в меню "File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
