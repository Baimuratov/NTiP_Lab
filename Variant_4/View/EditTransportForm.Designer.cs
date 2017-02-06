namespace View
{
    partial class EditTransportForm
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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._infoLabel = new System.Windows.Forms.Label();
            this.transportControl1 = new View.TransportControl();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(92, 199);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 25);
            this._okButton.TabIndex = 6;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
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
            // transportControl1
            // 
            this.transportControl1.Location = new System.Drawing.Point(14, 44);
            this.transportControl1.Name = "transportControl1";
            this.transportControl1.Object = null;
            this.transportControl1.ReadOnly = false;
            this.transportControl1.Size = new System.Drawing.Size(338, 135);
            this.transportControl1.TabIndex = 10;
            // 
            // EditTransportForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(375, 236);
            this.Controls.Add(this.transportControl1);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTransportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new transport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _infoLabel;
        private TransportControl transportControl1;
    }
}