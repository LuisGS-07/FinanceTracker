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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtUser.Tag = txtUser.Text;
            txtUser.Clear();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Tag = textBox2.Text;
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(txtUser.Text);
            frm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro frm = new Registro();
            frm.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
