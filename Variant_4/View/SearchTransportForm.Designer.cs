namespace View
{
    partial class SearchTransportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._resultsGridView = new System.Windows.Forms.DataGridView();
            this._searchButton = new System.Windows.Forms.Button();
            this._specificFuelConsumptionComboBox = new System.Windows.Forms.ComboBox();
            this._resultsGroupBox = new System.Windows.Forms.GroupBox();
            this._notFoundLabel = new System.Windows.Forms.Label();
            this._fuelConsumptionComboBox = new System.Windows.Forms.ComboBox();
            this._specificFuelConsumptionTextBox = new System.Windows.Forms.TextBox();
            this._fuelConsumptionTextBox = new System.Windows.Forms.TextBox();
            this._specificFuelConsumptionCheckBox = new System.Windows.Forms.CheckBox();
            this._fuelConsumptionCheckBox = new System.Windows.Forms.CheckBox();
            this._infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._resultsGridView)).BeginInit();
            this._resultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _resultsGridView
            // 
            this._resultsGridView.AllowUserToAddRows = false;
            this._resultsGridView.AllowUserToDeleteRows = false;
            this._resultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._resultsGridView.Location = new System.Drawing.Point(6, 19);
            this._resultsGridView.Name = "_resultsGridView";
            this._resultsGridView.ReadOnly = true;
            this._resultsGridView.Size = new System.Drawing.Size(475, 240);
            this._resultsGridView.TabIndex = 8;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(338, 42);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 25);
            this._searchButton.TabIndex = 7;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // _specificFuelConsumptionComboBox
            // 
            this._specificFuelConsumptionComboBox.FormattingEnabled = true;
            this._specificFuelConsumptionComboBox.Items.AddRange(new object[] {
            "<",
            "<=",
            "=",
            ">=",
            ">"});
            this._specificFuelConsumptionComboBox.Location = new System.Drawing.Point(165, 43);
            this._specificFuelConsumptionComboBox.Name = "_specificFuelConsumptionComboBox";
            this._specificFuelConsumptionComboBox.Size = new System.Drawing.Size(40, 21);
            this._specificFuelConsumptionComboBox.TabIndex = 3;
            // 
            // _resultsGroupBox
            // 
            this._resultsGroupBox.Controls.Add(this._notFoundLabel);
            this._resultsGroupBox.Controls.Add(this._resultsGridView);
            this._resultsGroupBox.Location = new System.Drawing.Point(12, 107);
            this._resultsGroupBox.Name = "_resultsGroupBox";
            this._resultsGroupBox.Size = new System.Drawing.Size(487, 265);
            this._resultsGroupBox.TabIndex = 9;
            this._resultsGroupBox.TabStop = false;
            this._resultsGroupBox.Text = "Search results";
            // 
            // _notFoundLabel
            // 
            this._notFoundLabel.AutoSize = true;
            this._notFoundLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._notFoundLabel.Location = new System.Drawing.Point(196, 69);
            this._notFoundLabel.Name = "_notFoundLabel";
            this._notFoundLabel.Size = new System.Drawing.Size(100, 13);
            this._notFoundLabel.TabIndex = 9;
            this._notFoundLabel.Text = "Transport not found";
            this._notFoundLabel.Visible = false;
            // 
            // _fuelConsumptionComboBox
            // 
            this._fuelConsumptionComboBox.FormattingEnabled = true;
            this._fuelConsumptionComboBox.Items.AddRange(new object[] {
            "<",
            "<=",
            "=",
            ">=",
            ">"});
            this._fuelConsumptionComboBox.Location = new System.Drawing.Point(165, 66);
            this._fuelConsumptionComboBox.Name = "_fuelConsumptionComboBox";
            this._fuelConsumptionComboBox.Size = new System.Drawing.Size(40, 21);
            this._fuelConsumptionComboBox.TabIndex = 4;
            // 
            // _specificFuelConsumptionTextBox
            // 
            this._specificFuelConsumptionTextBox.Location = new System.Drawing.Point(211, 43);
            this._specificFuelConsumptionTextBox.Name = "_specificFuelConsumptionTextBox";
            this._specificFuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._specificFuelConsumptionTextBox.TabIndex = 5;
            this._specificFuelConsumptionTextBox.TextChanged += new System.EventHandler(this.specificFuelConsumptionTextBox_TextChanged);
            // 
            // _fuelConsumptionTextBox
            // 
            this._fuelConsumptionTextBox.Location = new System.Drawing.Point(211, 66);
            this._fuelConsumptionTextBox.Name = "_fuelConsumptionTextBox";
            this._fuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._fuelConsumptionTextBox.TabIndex = 6;
            this._fuelConsumptionTextBox.TextChanged += new System.EventHandler(this.fuelConsumptionTextBox_TextChanged);
            // 
            // _specificFuelConsumptionCheckBox
            // 
            this._specificFuelConsumptionCheckBox.AutoSize = true;
            this._specificFuelConsumptionCheckBox.Checked = true;
            this._specificFuelConsumptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._specificFuelConsumptionCheckBox.Location = new System.Drawing.Point(12, 45);
            this._specificFuelConsumptionCheckBox.Name = "_specificFuelConsumptionCheckBox";
            this._specificFuelConsumptionCheckBox.Size = new System.Drawing.Size(147, 17);
            this._specificFuelConsumptionCheckBox.TabIndex = 1;
            this._specificFuelConsumptionCheckBox.Text = "Specific fuel consumption";
            this._specificFuelConsumptionCheckBox.UseVisualStyleBackColor = true;
            this._specificFuelConsumptionCheckBox.CheckedChanged += new System.EventHandler(this.specificFuelConsumptionCheckBox_CheckedChanged);
            // 
            // _fuelConsumptionCheckBox
            // 
            this._fuelConsumptionCheckBox.AutoSize = true;
            this._fuelConsumptionCheckBox.Checked = true;
            this._fuelConsumptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._fuelConsumptionCheckBox.Location = new System.Drawing.Point(12, 68);
            this._fuelConsumptionCheckBox.Name = "_fuelConsumptionCheckBox";
            this._fuelConsumptionCheckBox.Size = new System.Drawing.Size(109, 17);
            this._fuelConsumptionCheckBox.TabIndex = 2;
            this._fuelConsumptionCheckBox.Text = "Fuel consumption";
            this._fuelConsumptionCheckBox.UseVisualStyleBackColor = true;
            this._fuelConsumptionCheckBox.CheckedChanged += new System.EventHandler(this.fuelConsumptionCheckBox_CheckedChanged);
            // 
            // _infoLabel
            // 
            this._infoLabel.AutoSize = true;
            this._infoLabel.Location = new System.Drawing.Point(12, 14);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(342, 13);
            this._infoLabel.TabIndex = 10;
            this._infoLabel.Text = "Values must be positive integer or fractional number of comma-delimited";
            // 
            // SearchTransportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 384);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._fuelConsumptionCheckBox);
            this.Controls.Add(this._specificFuelConsumptionCheckBox);
            this.Controls.Add(this._fuelConsumptionTextBox);
            this.Controls.Add(this._specificFuelConsumptionTextBox);
            this.Controls.Add(this._fuelConsumptionComboBox);
            this.Controls.Add(this._resultsGroupBox);
            this.Controls.Add(this._specificFuelConsumptionComboBox);
            this.Controls.Add(this._searchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchTransportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search transport";
            ((System.ComponentModel.ISupportInitialize)(this._resultsGridView)).EndInit();
            this._resultsGroupBox.ResumeLayout(false);
            this._resultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _resultsGridView;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.ComboBox _specificFuelConsumptionComboBox;
        private System.Windows.Forms.GroupBox _resultsGroupBox;
        private System.Windows.Forms.ComboBox _fuelConsumptionComboBox;
        private System.Windows.Forms.TextBox _specificFuelConsumptionTextBox;
        private System.Windows.Forms.TextBox _fuelConsumptionTextBox;
        private System.Windows.Forms.CheckBox _specificFuelConsumptionCheckBox;
        private System.Windows.Forms.CheckBox _fuelConsumptionCheckBox;
        private System.Windows.Forms.Label _infoLabel;
        private System.Windows.Forms.Label _notFoundLabel;
    }
}