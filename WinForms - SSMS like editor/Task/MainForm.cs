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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        => Application.Exit();

        private void MainForm_Load(object sender, EventArgs e)
        {
            CbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        }

        private void CbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            LbTables.DataSource = (CbDatabases.SelectedItem as Database).Tables;
            LbViews.DataSource = (CbDatabases.SelectedItem as Database).Views;
            LbProcedures.DataSource = (CbDatabases.SelectedItem as Database).Procedures;
        }

        private void Clear()
        {
            LbTableColumns.DataSource = null;
            LbViewColumns.DataSource = null;
            LbProcParams.DataSource = null;
            TbProcDefinition.Text = string.Empty;
        }

        private void LbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbTableColumns.DataSource = (LbTables.SelectedItem as DBEntity).Columns;
        }

        private void LbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbViewColumns.DataSource = (LbViews.SelectedItem as DBEntity).Columns;
        }

        private void LbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbProcDefinition.Text = (LbProcedures.SelectedItem as Procedure).Definition;
            LbProcParams.DataSource = (LbProcedures.SelectedItem as Procedure).Parameters;
        }
    }
}
