using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task.Dal;
using Task.Models;

namespace Task
{
    public partial class ExecutionForm : Form
    {
        public ExecutionForm()
        {
            InitializeComponent();
            LoadDatabases();
        }

        private void LoadDatabases()
        {
            CbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            TbResult.Controls.Clear();

            string useCommand = $"use {CbDatabases.SelectedItem}" + "\n" + TbCommand.Text.Trim();
            DataGrid dg = new DataGrid();
            try
            {
                TextBox tb = new TextBox();
                tb.Width = TbResult.Width;
                tb.Height = TbResult.Height;
                tb.Enabled = false;

                DataSet dataSet = RepositoryFactory.GetRepository().Execute(useCommand);
                foreach (DataTable data in dataSet.Tables)
                {
                    dg.DataSource = data;
                    dg.Height = TbResult.Height;
                    dg.Width = TbResult.Width;
                    TbResult.Controls.Add(dg);
                    tb.Text = $"{data.Rows.Count} rows affected \n Completion time: {DateTime.Now}";
                    TbMessage.Controls.Add(tb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
