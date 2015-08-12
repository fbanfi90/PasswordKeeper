using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;

namespace PasswordKeeper
{
    public partial class MainForm : Form
    {
        #region Fields

        private Cipher cipher;
        private String dataFile = ConfigurationPath + "data.xml";
        private static String keyFile = ConfigurationPath + "key";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the path of the folder containing the configuration files.
        /// </summary>
        static private String ConfigurationPath
        {
            get
            {
                String commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                String companyName = ((AssemblyCompanyAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0]).Company;
                String productName = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
                return commonApplicationData + "\\" + companyName + "\\" + productName + "\\";
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainForm()
        {
            String key;
            using (AccessForm access = new AccessForm())
            {
                if (access.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                key = access.keyTextBox.Text;
            }
            if (String.IsNullOrEmpty(key))
            {
                MessageBox.Show("Wrong key!", "Password Keeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            if (!Directory.Exists(ConfigurationPath))
            {
                CreateDirectory(ConfigurationPath);
            }
            if (File.Exists(keyFile))
            {
                using (Cipher cipher = new Cipher(key))
                {
                    if (key != cipher.Decrypt(File.ReadAllText(keyFile)))
                    {
                        MessageBox.Show("Wrong key!", "Password Keeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Stream stream = File.Create(keyFile);
                using (Cipher cipher = new Cipher(key))
                {
                    String encrypted = cipher.Encrypt(key);
                    stream.Write(Encoding.ASCII.GetBytes(encrypted), 0, encrypted.Length);
                }
            }
            InitializeComponent();
            this.cipher = new Cipher(key);
            key = String.Empty;
        }

        #endregion

        #region Methods

        #region Helpers

        /// <summary>
        /// Create a full access directory.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        private static void CreateDirectory(String path)
        {
            DirectoryInfo directoryInfo;
            DirectorySecurity directorySecurity;
            AccessRule accessRule;
            SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
            directoryInfo = Directory.CreateDirectory(path);
            directorySecurity = directoryInfo.GetAccessControl();
            accessRule = new FileSystemAccessRule(securityIdentifier, FileSystemRights.Write | FileSystemRights.ReadAndExecute | FileSystemRights.Modify, AccessControlType.Allow);
            Boolean modified;
            directorySecurity.ModifyAccessRule(AccessControlModification.Add, accessRule, out modified);
            directoryInfo.SetAccessControl(directorySecurity);
        }

        /// <summary>
        /// Detect whether the user changed data in the Form.
        /// </summary>
        private Boolean Changed()
        {
            if (!File.Exists(dataFile))
            {
                return dataTable.Rows.Count != 0;
            }
            else
            {
                DataTable oldDataTable = dataTable.Clone();
                oldDataTable.ReadXml(dataFile);
                if (dataTable.Rows.Count != oldDataTable.Rows.Count)
                {
                    return true;
                }
                else
                {
                    foreach (DataRow row in oldDataTable.Rows)
                    {
                        foreach (DataColumn column in oldDataTable.Columns)
                        {
                            row[column] = cipher.Decrypt(row[column] as String);
                        }
                    }
                    for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (Int32 j = 0; j < dataTable.Columns.Count; j++)
                        {
                            if (!dataTable.Rows[i][j].Equals(oldDataTable.Rows[i][j]))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Export encrypted data to XML.
        /// </summary>
        private void Save()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    row[column] = cipher.Encrypt(row[column] as String);
                }
            }
            dataSet.WriteXml(dataFile);
            cipher.Dispose();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fill the Form with the decrypted data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormLoad(Object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(dataFile))
                {
                    dataSet.ReadXml(dataFile);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            row[column] = cipher.Decrypt(row[column] as String);
                        }
                    }
                    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Check whether there were changes before closing the Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormFormClosing(Object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Changed())
                {
                    DialogResult result = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewEditingControlShowing(Object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView.CurrentRow.Tag != null)
            {
                e.Control.Text = dataGridView.CurrentRow.Cells[dataGridView.CurrentCell.ColumnIndex].Value.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellFormatting(Object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "passwordDataGridViewTextBoxColumn" && e.Value != null)
            {
                dataGridView.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String((Char)0x25cf, e.Value.ToString().Length);
            }
        }

        #endregion

        #endregion
    }
}