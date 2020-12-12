using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scaffolding.Classes;

namespace Scaffolding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            TableNameListBox.DataSource = Operations.TableNames();
        }

        private void GenerateSingleClassButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClassResultsTextBox.Text = Operations.GenerateClass(TableNameListBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
    }
}
