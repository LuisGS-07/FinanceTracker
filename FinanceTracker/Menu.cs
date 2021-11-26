using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceTracker
{
    public partial class Menu : Form
    {
        private string username = "";
        public Menu(string user)
        {
            InitializeComponent();
            this.username = user;
            txtUser.Text = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex==0)
            {
                Efectiva frm = new Efectiva(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }
            else if(cboType.SelectedIndex==1)
            {
                Nominal frm = new Nominal(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }


        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                FacturaEfectiva frm = new FacturaEfectiva(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }
            else if (cboType.SelectedIndex == 1)
            {
                FacturaNominal frm = new FacturaNominal(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                ReciboEfectiva frm = new ReciboEfectiva(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }
            else if (cboType.SelectedIndex == 1)
            {
                RecibosNonimal frm = new RecibosNonimal(username);
                txtUser.Text = username;
                frm.ShowDialog();
            }
        }
    }
}
