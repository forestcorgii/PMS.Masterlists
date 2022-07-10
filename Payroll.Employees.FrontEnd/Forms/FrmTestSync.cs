using Payroll.Employees.Domain;
using Payroll.Employees.FrontEnd.Test.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll.Employees.FrontEnd.Test
{
    public partial class FrmTestSync : Form
    {
        EmployeeController Controller;
        public FrmTestSync()
        {
            InitializeComponent();

            Controller = new();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Controller.LoadEmployees();
        }


        private async void BtnFindOnServer_Click(object sender, EventArgs e)
        {
            Employee? employeeFound = await Controller.FindEmployeeAsync(TbEEId.Text);
            if (employeeFound is not null)
                Controller.SaveEmployee(employeeFound);
            dataGridView1.DataSource = Controller.LoadEmployees();
         }
    }
}
