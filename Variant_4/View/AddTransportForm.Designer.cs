namespace View
{
    partial class AddTransportForm
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
            this._carRadioButton = new System.Windows.Forms.RadioButton();
            this._helicopterRadioButton = new System.Windows.Forms.RadioButton();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._propertiesLabel = new System.Windows.Forms.Label();
            this._randomDataButton = new System.Windows.Forms.Button();
            this._specificFuelConsumptionTextBox = new System.Windows.Forms.TextBox();
            this._droveKilometersTextBox = new System.Windows.Forms.TextBox();
            this._hoursInAirTextBox = new System.Windows.Forms.TextBox();
            this._infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _carRadioButton
            // 
            this._carRadioButton.AutoSize = true;
            this._carRadioButton.Checked = true;
            this._carRadioButton.Location = new System.Drawing.Point(283, 75);
            this._carRadioButton.Name = "_carRadioButton";
            this._carRadioButton.Size = new System.Drawing.Size(41, 17);
            this._carRadioButton.TabIndex = 4;
            this._carRadioButton.TabStop = true;
            this._carRadioButton.Text = "Car";
            this._carRadioButton.UseVisualStyleBackColor = true;
            this._carRadioButton.CheckedChanged += new System.EventHandler(this.carRadioButton_CheckedChanged);
            // 
            // _helicopterRadioButton
            // 
            this._helicopterRadioButton.AutoSize = true;
            this._helicopterRadioButton.Location = new System.Drawing.Point(283, 98);
            this._helicopterRadioButton.Name = "_helicopterRadioButton";
            this._helicopterRadioButton.Size = new System.Drawing.Size(73, 17);
            this._helicopterRadioButton.TabIndex = 5;
            this._helicopterRadioButton.Text = "Helicopter";
            this._helicopterRadioButton.UseVisualStyleBackColor = true;
            this._helicopterRadioButton.CheckedChanged += new System.EventHandler(this.helicopterRadioButton_CheckedChanged);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(92, 199);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 25);
            this._okButton.TabIndex = 6;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(210, 199);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 25);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _propertiesLabel
            // 
            this._propertiesLabel.AutoSize = true;
            this._propertiesLabel.Location = new System.Drawing.Point(12, 51);
            this._propertiesLabel.Name = "_propertiesLabel";
            this._propertiesLabel.Size = new System.Drawing.Size(128, 65);
            this._propertiesLabel.TabIndex = 8;
            this._propertiesLabel.Text = "Specific fuel consumption\r\n\r\nDrove kilometers\r\n\r\nHours in air";
            // 
            // _randomDataButton
            // 
            this._randomDataButton.Location = new System.Drawing.Point(15, 141);
            this._randomDataButton.Name = "_randomDataButton";
            this._randomDataButton.Size = new System.Drawing.Size(116, 25);
            this._randomDataButton.TabIndex = 8;
            this._randomDataButton.Text = "Create Random Data";
            this._randomDataButton.UseVisualStyleBackColor = true;
            this._randomDataButton.Click += new System.EventHandler(this.randomDataButton_Click);
            // 
            // _specificFuelConsumptionTextBox
            // 
            this._specificFuelConsumptionTextBox.Location = new System.Drawing.Point(146, 48);
            this._specificFuelConsumptionTextBox.Name = "_specificFuelConsumptionTextBox";
            this._specificFuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._specificFuelConsumptionTextBox.TabIndex = 0;
            this._specificFuelConsumptionTextBox.TextChanged += new System.EventHandler(this.specificFuelConsumptionTextBox_TextChanged);
            // 
            // _droveKilometersTextBox
            // 
            this._droveKilometersTextBox.Location = new System.Drawing.Point(146, 74);
            this._droveKilometersTextBox.Name = "_droveKilometersTextBox";
            this._droveKilometersTextBox.Size = new System.Drawing.Size(100, 20);
            this._droveKilometersTextBox.TabIndex = 1;
            this._droveKilometersTextBox.TextChanged += new System.EventHandler(this.droveKilometersTextBox_TextChanged);
            // 
            // _hoursInAirTextBox
            // 
            this._hoursInAirTextBox.Enabled = false;
            this._hoursInAirTextBox.Location = new System.Drawing.Point(146, 100);
            this._hoursInAirTextBox.Name = "_hoursInAirTextBox";
            this._hoursInAirTextBox.Size = new System.Drawing.Size(100, 20);
            this._hoursInAirTextBox.TabIndex = 2;
            this._hoursInAirTextBox.TextChanged += new System.EventHandler(this.hoursInAirTextBox_TextChanged);
            // 
            // _infoLabel
            // 
            this._infoLabel.AutoSize = true;
            this._infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._infoLabel.Location = new System.Drawing.Point(12, 15);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(342, 13);
            this._infoLabel.TabIndex = 9;
            this._infoLabel.Text = "Values must be positive integer or fractional number of comma-delimited";
            // 
            // AddTransportForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(375, 236);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._hoursInAirTextBox);
            this.Controls.Add(this._droveKilometersTextBox);
            this.Controls.Add(this._specificFuelConsumptionTextBox);
            this.Controls.Add(this._randomDataButton);
            this.Controls.Add(this._propertiesLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._helicopterRadioButton);
            this.Controls.Add(this._carRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTransportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new transport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton _carRadioButton;
        private System.Windows.Forms.RadioButton _helicopterRadioButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _propertiesLabel;
        private System.Windows.Forms.Button _randomDataButton;
        private System.Windows.Forms.TextBox _specificFuelConsumptionTextBox;
        private System.Windows.Forms.TextBox _droveKilometersTextBox;
        private System.Windows.Forms.TextBox _hoursInAirTextBox;
        private System.Windows.Forms.Label _infoLabel;

    }
}