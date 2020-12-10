using System;
using System.Windows.Forms;
using StoredProcedureEntityFrameworkCore1.Context;
using StoredProcedureEntityFrameworkCore1.ProcedureClasses;


namespace StoredProcedureEntityFrameworkCore1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void RunButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            await using var context = new NorthwindContext();
            var storedProcedures = new StoredProcedures(context);
            var results = await storedProcedures.CustomersByCountryIdentifier(12);

            foreach (var result in results)
            {
                listBox1.Items.Add(result);
            }

        }
    }
}
