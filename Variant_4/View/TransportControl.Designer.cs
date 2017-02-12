namespace View
{
    partial class TransportControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._hoursInAirTextBox = new System.Windows.Forms.TextBox();
            this._droveKilometersTextBox = new System.Windows.Forms.TextBox();
            this._specificFuelConsumptionTextBox = new System.Windows.Forms.TextBox();
            this._propertiesLabel = new System.Windows.Forms.Label();
            this._helicopterRadioButton = new System.Windows.Forms.RadioButton();
            this._carRadioButton = new System.Windows.Forms.RadioButton();
            this._randomDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _hoursInAirTextBox
            // 
            this._hoursInAirTextBox.Enabled = false;
            this._hoursInAirTextBox.Location = new System.Drawing.Point(131, 29);
            this._hoursInAirTextBox.Name = "_hoursInAirTextBox";
            this._hoursInAirTextBox.Size = new System.Drawing.Size(100, 20);
            this._hoursInAirTextBox.TabIndex = 11;
            this._hoursInAirTextBox.TextChanged += new System.EventHandler(this._hoursInAirTextBox_TextChanged);
            // 
            // _droveKilometersTextBox
            // 
            this._droveKilometersTextBox.Location = new System.Drawing.Point(131, 3);
            this._droveKilometersTextBox.Name = "_droveKilometersTextBox";
            this._droveKilometersTextBox.Size = new System.Drawing.Size(100, 20);
            this._droveKilometersTextBox.TabIndex = 10;
            this._droveKilometersTextBox.TextChanged += new System.EventHandler(this._droveKilometersTextBox_TextChanged);
            // 
            // _specificFuelConsumptionTextBox
            // 
            this._specificFuelConsumptionTextBox.Location = new System.Drawing.Point(131, 55);
            this._specificFuelConsumptionTextBox.Name = "_specificFuelConsumptionTextBox";
            this._specificFuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._specificFuelConsumptionTextBox.TabIndex = 9;
            this._specificFuelConsumptionTextBox.TextChanged += new System.EventHandler(this._specificFuelConsumptionTextBox_TextChanged);
            // 
            // _propertiesLabel
            // 
            this._propertiesLabel.AutoSize = true;
            this._propertiesLabel.Location = new System.Drawing.Point(-3, 6);
            this._propertiesLabel.Name = "_propertiesLabel";
            this._propertiesLabel.Size = new System.Drawing.Size(128, 65);
            this._propertiesLabel.TabIndex = 14;
            this._propertiesLabel.Text = "Drove kilometers\r\n\r\nHours in air\r\n\r\nSpecific fuel consumption";
            // 
            // _helicopterRadioButton
            // 
            this._helicopterRadioButton.AutoSize = true;
            this._helicopterRadioButton.Location = new System.Drawing.Point(268, 27);
            this._helicopterRadioButton.Name = "_helicopterRadioButton";
            this._helicopterRadioButton.Size = new System.Drawing.Size(73, 17);
            this._helicopterRadioButton.TabIndex = 13;
            this._helicopterRadioButton.Text = "Helicopter";
            this._helicopterRadioButton.UseVisualStyleBackColor = true;
            this._helicopterRadioButton.CheckedChanged += new System.EventHandler(this._helicopterRadioButton_CheckedChanged);
            // 
            // _carRadioButton
            // 
            this._carRadioButton.AutoSize = true;
            this._carRadioButton.Checked = true;
            this._carRadioButton.Location = new System.Drawing.Point(268, 4);
            this._carRadioButton.Name = "_carRadioButton";
            this._carRadioButton.Size = new System.Drawing.Size(41, 17);
            this._carRadioButton.TabIndex = 12;
            this._carRadioButton.TabStop = true;
            this._carRadioButton.Text = "Car";
            this._carRadioButton.UseVisualStyleBackColor = true;
            this._carRadioButton.CheckedChanged += new System.EventHandler(this._carRadioButton_CheckedChanged);
            // 
            // _randomDataButton
            // 
            this._randomDataButton.Location = new System.Drawing.Point(0, 110);
            this._randomDataButton.Name = "_randomDataButton";
            this._randomDataButton.Size = new System.Drawing.Size(116, 25);
            this._randomDataButton.TabIndex = 15;
            this._randomDataButton.Text = "Create Random Data";
            this._randomDataButton.UseVisualStyleBackColor = true;
            this._randomDataButton.Click += new System.EventHandler(this._randomDataButton_Click);
            // 
            // TransportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._randomDataButton);
            this.Controls.Add(this._hoursInAirTextBox);
            this.Controls.Add(this._droveKilometersTextBox);
            this.Controls.Add(this._specificFuelConsumptionTextBox);
            this.Controls.Add(this._propertiesLabel);
            this.Controls.Add(this._helicopterRadioButton);
            this.Controls.Add(this._carRadioButton);
            this.Name = "TransportControl";
            this.Size = new System.Drawing.Size(338, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _hoursInAirTextBox;
        private System.Windows.Forms.TextBox _droveKilometersTextBox;
        private System.Windows.Forms.TextBox _specificFuelConsumptionTextBox;
        private System.Windows.Forms.Label _propertiesLabel;
        private System.Windows.Forms.RadioButton _helicopterRadioButton;
        private System.Windows.Forms.RadioButton _carRadioButton;
        private System.Windows.Forms.Button _randomDataButton;
    }
}
