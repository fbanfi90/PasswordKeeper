namespace PasswordKeeper
{
    partial class AccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessForm));
            this.okButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.showCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(108, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(12, 12);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(171, 20);
            this.keyTextBox.TabIndex = 0;
            this.keyTextBox.UseSystemPasswordChar = true;
            // 
            // showCheckBox
            // 
            this.showCheckBox.AutoSize = true;
            this.showCheckBox.Location = new System.Drawing.Point(12, 42);
            this.showCheckBox.Name = "showCheckBox";
            this.showCheckBox.Size = new System.Drawing.Size(73, 17);
            this.showCheckBox.TabIndex = 2;
            this.showCheckBox.Text = "Show key";
            this.showCheckBox.UseVisualStyleBackColor = true;
            this.showCheckBox.CheckedChanged += new System.EventHandler(this.ShowCheckBoxCheckedChanged);
            // 
            // AccessForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 73);
            this.Controls.Add(this.showCheckBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Keeper";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.CheckBox showCheckBox;
    }
}