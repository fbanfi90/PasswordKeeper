namespace PasswordKeeper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.diasplayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet = new System.Data.DataSet();
            this.dataTable = new System.Data.DataTable();
            this.displayNameDataColumn = new System.Data.DataColumn();
            this.usernameEmailDataColumn = new System.Data.DataColumn();
            this.passwordDataColumn = new System.Data.DataColumn();
            this.notesDataColumn = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diasplayNameDataGridViewTextBoxColumn,
            this.usernameEmailDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn});
            this.dataGridView.DataMember = "Password";
            this.dataGridView.DataSource = this.dataSet;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.Size = new System.Drawing.Size(634, 362);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewEditingControlShowing);
            // 
            // diasplayNameDataGridViewTextBoxColumn
            // 
            this.diasplayNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.diasplayNameDataGridViewTextBoxColumn.DataPropertyName = "Diasplay Name";
            this.diasplayNameDataGridViewTextBoxColumn.HeaderText = "Diasplay Name";
            this.diasplayNameDataGridViewTextBoxColumn.MinimumWidth = 140;
            this.diasplayNameDataGridViewTextBoxColumn.Name = "diasplayNameDataGridViewTextBoxColumn";
            this.diasplayNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // usernameEmailDataGridViewTextBoxColumn
            // 
            this.usernameEmailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.usernameEmailDataGridViewTextBoxColumn.DataPropertyName = "Username / E-mail";
            this.usernameEmailDataGridViewTextBoxColumn.HeaderText = "Username / E-mail";
            this.usernameEmailDataGridViewTextBoxColumn.MinimumWidth = 140;
            this.usernameEmailDataGridViewTextBoxColumn.Name = "usernameEmailDataGridViewTextBoxColumn";
            this.usernameEmailDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.MinimumWidth = 140;
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.MinimumWidth = 140;
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "Password Keeper";
            this.dataSet.Locale = new System.Globalization.CultureInfo("");
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable});
            // 
            // dataTable
            // 
            this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.displayNameDataColumn,
            this.usernameEmailDataColumn,
            this.passwordDataColumn,
            this.notesDataColumn});
            this.dataTable.TableName = "Password";
            // 
            // displayNameDataColumn
            // 
            this.displayNameDataColumn.ColumnName = "Diasplay Name";
            // 
            // usernameEmailDataColumn
            // 
            this.usernameEmailDataColumn.ColumnName = "Username / E-mail";
            // 
            // passwordDataColumn
            // 
            this.passwordDataColumn.ColumnName = "Password";
            // 
            // notesDataColumn
            // 
            this.notesDataColumn.ColumnName = "Notes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Keeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable dataTable;
        private System.Data.DataColumn displayNameDataColumn;
        private System.Data.DataColumn usernameEmailDataColumn;
        private System.Data.DataColumn passwordDataColumn;
        private System.Data.DataColumn notesDataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasplayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
    }
}

