using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PasswordKeeper
{
    public partial class AccessForm : Form
    {
        public AccessForm()
        {
            InitializeComponent();
        }

        private void OkButtonClick(Object sender, EventArgs e)
        {
            Close();
        }

        private void ShowCheckBoxCheckedChanged(Object sender, EventArgs e)
        {
            keyTextBox.UseSystemPasswordChar = !showCheckBox.Checked;
            keyTextBox.Focus();
        }
    }
}
