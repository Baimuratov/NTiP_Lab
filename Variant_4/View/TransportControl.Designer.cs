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
            this._generalPropertiesLabel = new System.Windows.Forms.Label();
            this._helicopterRadioButton = new System.Windows.Forms.RadioButton();
            this._carRadioButton = new System.Windows.Forms.RadioButton();
            this._randomDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._specificPropertiesLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _hoursInAirTextBox
            // 
            this._hoursInAirTextBox.Location = new System.Drawing.Point(140, 48);
            this._hoursInAirTextBox.Name = "_hoursInAirTextBox";
            this._hoursInAirTextBox.Size = new System.Drawing.Size(100, 20);
            this._hoursInAirTextBox.TabIndex = 11;
            this._hoursInAirTextBox.TextChanged += new System.EventHandler(this._hoursInAirTextBox_TextChanged);
            // 
            // _droveKilometersTextBox
            // 
            this._droveKilometersTextBox.Location = new System.Drawing.Point(140, 48);
            this._droveKilometersTextBox.Name = "_droveKilometersTextBox";
            this._droveKilometersTextBox.Size = new System.Drawing.Size(100, 20);
            this._droveKilometersTextBox.TabIndex = 10;
            this._droveKilometersTextBox.TextChanged += new System.EventHandler(this._droveKilometersTextBox_TextChanged);
            // 
            // _specificFuelConsumptionTextBox
            // 
            this._specificFuelConsumptionTextBox.Location = new System.Drawing.Point(140, 22);
            this._specificFuelConsumptionTextBox.Name = "_specificFuelConsumptionTextBox";
            this._specificFuelConsumptionTextBox.Size = new System.Drawing.Size(100, 20);
            this._specificFuelConsumptionTextBox.TabIndex = 9;
            this._specificFuelConsumptionTextBox.TextChanged += new System.EventHandler(this._specificFuelConsumptionTextBox_TextChanged);
            // 
            // _generalPropertiesLabel
            // 
            this._generalPropertiesLabel.AutoSize = true;
            this._generalPropertiesLabel.Location = new System.Drawing.Point(6, 25);
            this._generalPropertiesLabel.Name = "_generalPropertiesLabel";
            this._generalPropertiesLabel.Size = new System.Drawing.Size(128, 13);
            this._generalPropertiesLabel.TabIndex = 14;
            this._generalPropertiesLabel.Text = "Specific fuel consumption";
            // 
            // _helicopterRadioButton
            // 
            this._helicopterRadioButton.AutoSize = true;
            this._helicopterRadioButton.Location = new System.Drawing.Point(53, 17);
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
            this._carRadioButton.Location = new System.Drawing.Point(6, 17);
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
            this._randomDataButton.Location = new System.Drawing.Point(0, 155);
            this._randomDataButton.Name = "_randomDataButton";
            this._randomDataButton.Size = new System.Drawing.Size(116, 25);
            this._randomDataButton.TabIndex = 15;
            this._randomDataButton.Text = "Create Random Data";
            this._randomDataButton.UseVisualStyleBackColor = true;
            this._randomDataButton.Click += new System.EventHandler(this._randomDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._carRadioButton);
            this.groupBox1.Controls.Add(this._helicopterRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 40);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._specificPropertiesLabel);
            this.groupBox2.Controls.Add(this._generalPropertiesLabel);
            this.groupBox2.Controls.Add(this._specificFuelConsumptionTextBox);
            this.groupBox2.Controls.Add(this._droveKilometersTextBox);
            this.groupBox2.Controls.Add(this._hoursInAirTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // _specificPropertiesLabel
            // 
            this._specificPropertiesLabel.AutoSize = true;
            this._specificPropertiesLabel.Location = new System.Drawing.Point(6, 51);
            this._specificPropertiesLabel.Name = "_specificPropertiesLabel";
            this._specificPropertiesLabel.Size = new System.Drawing.Size(86, 13);
            this._specificPropertiesLabel.TabIndex = 18;
            this._specificPropertiesLabel.Text = "Drove kilometers";
            // 
            // TransportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._randomDataButton);
            this.Name = "TransportControl";
            this.Size = new System.Drawing.Size(338, 182);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _hoursInAirTextBox;
        private System.Windows.Forms.TextBox _droveKilometersTextBox;
        private System.Windows.Forms.TextBox _specificFuelConsumptionTextBox;
        private System.Windows.Forms.Label _generalPropertiesLabel;
        private System.Windows.Forms.RadioButton _helicopterRadioButton;
        private System.Windows.Forms.RadioButton _carRadioButton;
        private System.Windows.Forms.Button _randomDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label _specificPropertiesLabel;
    }
}
