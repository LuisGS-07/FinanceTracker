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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(txtUser.Text);
            frm.ShowDialog();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
