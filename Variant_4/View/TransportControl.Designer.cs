﻿namespace View
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
            this._generalPropertiesLabel = new System.Windows.Forms.Label();
            this._helicopterRadioButton = new System.Windows.Forms.RadioButton();
            this._carRadioButton = new System.Windows.Forms.RadioButton();
            this._randomDataButton = new System.Windows.Forms.Button();
            this._specificPropertiesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _hoursInAirTextBox
            // 
            this._hoursInAirTextBox.Location = new System.Drawing.Point(137, 61);
            this._hoursInAirTextBox.Name = "_hoursInAirTextBox";
            this._hoursInAirTextBox.Size = new System.Drawing.Size(100, 20);
            this._hoursInAirTextBox.TabIndex = 11;
            this._hoursInAirTextBox.TextChanged += new System.EventHandler(this._hoursInAirTextBox_TextChanged);
            // 
            // _droveKilometersTextBox
            // 
            this._droveKilometersTextBox.Location = new System.Drawing.Point(137, 61);
            this._droveKilometersTextBox.Name = "_droveKilometersTextBox";
            this._droveKilometersTextBox.Size = new System.Drawing.Size(100, 20);
            this._droveKilometersTextBox.TabIndex = 10;
            this._droveKilometersTextBox.TextChanged += new System.EventHandler(this._droveKilometersTextBox_TextChanged);
            // 
            // _specificFuelConsumptionTextBox
            // 
            this._specificFuelConsumptionTextBox.Location = new System.Drawing.Point(137, 35);
            this._specificFuelConsumptionTextBox.Name = "_specificFuelConsumptionTextBox";
            this._specificFuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._specificFuelConsumptionTextBox.TabIndex = 9;
            this._specificFuelConsumptionTextBox.TextChanged += new System.EventHandler(this._specificFuelConsumptionTextBox_TextChanged);
            // 
            // _generalPropertiesLabel
            // 
            this._generalPropertiesLabel.AutoSize = true;
            this._generalPropertiesLabel.Location = new System.Drawing.Point(3, 38);
            this._generalPropertiesLabel.Name = "_generalPropertiesLabel";
            this._generalPropertiesLabel.Size = new System.Drawing.Size(128, 13);
            this._generalPropertiesLabel.TabIndex = 14;
            this._generalPropertiesLabel.Text = "Specific fuel consumption";
            // 
            // _helicopterRadioButton
            // 
            this._helicopterRadioButton.AutoSize = true;
            this._helicopterRadioButton.Location = new System.Drawing.Point(50, 3);
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
            this._carRadioButton.Location = new System.Drawing.Point(3, 3);
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
            this._randomDataButton.Location = new System.Drawing.Point(3, 87);
            this._randomDataButton.Name = "_randomDataButton";
            this._randomDataButton.Size = new System.Drawing.Size(116, 25);
            this._randomDataButton.TabIndex = 15;
            this._randomDataButton.Text = "Create Random Data";
            this._randomDataButton.UseVisualStyleBackColor = true;
            this._randomDataButton.Click += new System.EventHandler(this._randomDataButton_Click);
            // 
            // _specificPropertiesLabel
            // 
            this._specificPropertiesLabel.AutoSize = true;
            this._specificPropertiesLabel.Location = new System.Drawing.Point(3, 64);
            this._specificPropertiesLabel.Name = "_specificPropertiesLabel";
            this._specificPropertiesLabel.Size = new System.Drawing.Size(86, 13);
            this._specificPropertiesLabel.TabIndex = 18;
            this._specificPropertiesLabel.Text = "Drove kilometers";
            // 
            // TransportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._specificPropertiesLabel);
            this.Controls.Add(this._carRadioButton);
            this.Controls.Add(this._generalPropertiesLabel);
            this.Controls.Add(this._specificFuelConsumptionTextBox);
            this.Controls.Add(this._droveKilometersTextBox);
            this.Controls.Add(this._randomDataButton);
            this.Controls.Add(this._hoursInAirTextBox);
            this.Controls.Add(this._helicopterRadioButton);
            this.Name = "TransportControl";
            this.Size = new System.Drawing.Size(338, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _hoursInAirTextBox;
        private System.Windows.Forms.TextBox _droveKilometersTextBox;
        private System.Windows.Forms.TextBox _specificFuelConsumptionTextBox;
        private System.Windows.Forms.Label _generalPropertiesLabel;
        private System.Windows.Forms.RadioButton _helicopterRadioButton;
        private System.Windows.Forms.RadioButton _carRadioButton;
        private System.Windows.Forms.Button _randomDataButton;
        private System.Windows.Forms.Label _specificPropertiesLabel;
    }
}
