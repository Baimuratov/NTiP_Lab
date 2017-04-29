namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._transportListGroupBox = new System.Windows.Forms.GroupBox();
            this._transportListGridView = new System.Windows.Forms.DataGridView();
            this._addButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            this._searchButton = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._modifyButton = new System.Windows.Forms.Button();
            this._transportControl = new View.TransportControl();
            this._fuelConsumptionTextBox = new System.Windows.Forms.TextBox();
            this._fuelConsumptionLabel = new System.Windows.Forms.Label();
            this._transportListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._transportListGridView)).BeginInit();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _transportListGroupBox
            // 
            this._transportListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._transportListGroupBox.Controls.Add(this._transportListGridView);
            this._transportListGroupBox.Location = new System.Drawing.Point(356, 27);
            this._transportListGroupBox.Name = "_transportListGroupBox";
            this._transportListGroupBox.Size = new System.Drawing.Size(439, 461);
            this._transportListGroupBox.TabIndex = 0;
            this._transportListGroupBox.TabStop = false;
            this._transportListGroupBox.Text = "List of transport";
            // 
            // _transportListGridView
            // 
            this._transportListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._transportListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._transportListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._transportListGridView.Location = new System.Drawing.Point(3, 16);
            this._transportListGridView.Name = "_transportListGridView";
            this._transportListGridView.ReadOnly = true;
            this._transportListGridView.Size = new System.Drawing.Size(433, 442);
            this._transportListGridView.TabIndex = 0;
            this._transportListGridView.SelectionChanged += new System.EventHandler(this._transportListGridView_SelectionChanged);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(12, 216);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(200, 27);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add Transport";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(12, 300);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(200, 27);
            this._removeButton.TabIndex = 2;
            this._removeButton.Text = "Remove Transport";
            this._removeButton.UseVisualStyleBackColor = true;
            this._removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(12, 342);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(200, 27);
            this._searchButton.TabIndex = 3;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(807, 24);
            this._menuStrip.TabIndex = 4;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newToolStripMenuItem,
            this.toolStripSeparator1,
            this._openToolStripMenuItem,
            this.toolStripSeparator2,
            this._saveToolStripMenuItem,
            this._saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this._closeToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _newToolStripMenuItem
            // 
            this._newToolStripMenuItem.Name = "_newToolStripMenuItem";
            this._newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._newToolStripMenuItem.Text = "New";
            this._newToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this._newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._openToolStripMenuItem.Text = "Open";
            this._openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._saveToolStripMenuItem.Text = "Save";
            this._saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // _saveAsToolStripMenuItem
            // 
            this._saveAsToolStripMenuItem.Name = "_saveAsToolStripMenuItem";
            this._saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._saveAsToolStripMenuItem.Text = "Save as";
            this._saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // _closeToolStripMenuItem
            // 
            this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
            this._closeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._closeToolStripMenuItem.Text = "Close";
            this._closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Transport list files (*.tl)|*.tl|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Transport list files (*.tl)|*.tl";
            // 
            // _modifyButton
            // 
            this._modifyButton.Location = new System.Drawing.Point(12, 258);
            this._modifyButton.Name = "_modifyButton";
            this._modifyButton.Size = new System.Drawing.Size(200, 27);
            this._modifyButton.TabIndex = 6;
            this._modifyButton.Text = "Modify Transport";
            this._modifyButton.UseVisualStyleBackColor = true;
            this._modifyButton.Click += new System.EventHandler(this._modifyButton_Click);
            // 
            // _transportControl
            // 
            this._transportControl.Location = new System.Drawing.Point(12, 24);
            this._transportControl.Name = "_transportControl";
            this._transportControl.Object = null;
            this._transportControl.ReadOnly = false;
            this._transportControl.Size = new System.Drawing.Size(338, 186);
            this._transportControl.TabIndex = 7;
            // 
            // _fuelConsumptionTextBox
            // 
            this._fuelConsumptionTextBox.Location = new System.Drawing.Point(154, 147);
            this._fuelConsumptionTextBox.Name = "_fuelConsumptionTextBox";
            this._fuelConsumptionTextBox.ReadOnly = true;
            this._fuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._fuelConsumptionTextBox.TabIndex = 8;
            // 
            // _fuelConsumptionLabel
            // 
            this._fuelConsumptionLabel.AutoSize = true;
            this._fuelConsumptionLabel.Location = new System.Drawing.Point(20, 150);
            this._fuelConsumptionLabel.Name = "_fuelConsumptionLabel";
            this._fuelConsumptionLabel.Size = new System.Drawing.Size(90, 13);
            this._fuelConsumptionLabel.TabIndex = 9;
            this._fuelConsumptionLabel.Text = "Fuel consumption";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 500);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._fuelConsumptionLabel);
            this.Controls.Add(this._fuelConsumptionTextBox);
            this.Controls.Add(this._transportControl);
            this.Controls.Add(this._modifyButton);
            this.Controls.Add(this._searchButton);
            this.Controls.Add(this._removeButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._transportListGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transport Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this._transportListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._transportListGridView)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _transportListGroupBox;
        private System.Windows.Forms.DataGridView _transportListGridView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button _modifyButton;
        private TransportControl _transportControl;
        private System.Windows.Forms.TextBox _fuelConsumptionTextBox;
        private System.Windows.Forms.Label _fuelConsumptionLabel;
    }
}

