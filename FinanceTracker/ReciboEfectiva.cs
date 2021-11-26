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
    public partial class ReciboEfectiva : Form
    {
        private string username = "";
        public ReciboEfectiva(string user)
        {
            InitializeComponent();
            this.username = user;
        }

        private void ReciboEfectiva_Load(object sender, EventArgs e)
        {

        }



        double valNeto = 0;//valor neto 
        double descuento = 0;//descuento 
        double entregado = 0;//valor entregado
        double recibido = 0;//valor recibido
        double TCEA = 0;
        double retencion = 0;
        double tasa = 0;//es la tasa descontada
        double costesInciales = 0;//costes inciales de la operacion
        double costesFinales = 0;//costes finales de la operación

        //variables para los costes inciales
        int count = 0;
        private double[] aux = new double[10];
        double aux2;
        //variables para los costes finales
        int count2 = 0;
        private double[] arreglo = new double[10];
        double ar;

        double TE = 0;//tasa efectiva en el periodo de dias que transcurre la operación

        void Restart()
        {

            txtNominal.Text = "";
            txtRetenciones.Text = "";
            txtTasa.Text = "";
            cboPlazoTasa.SelectedIndex = -1;
            txtCostoInicial.Text = "";
            txtCostoFinal.Text = "";
            cboInicial.SelectedIndex = -1;
            cboFinal.SelectedIndex = -1;

            valNeto = 0;
            descuento = 0;
            entregado = 0;
            recibido = 0;
            TCEA = 0;
            retencion = 0;
            tasa = 0;
            costesInciales = 0;
            costesFinales = 0;

            for (int i = 0; i < lstInicial.Items.Count; i++)
            {
                lstInicial.Items.RemoveAt(i);
            }
            for (int i = 0; i < lstFinal.Items.Count; i++)
            {
                lstFinal.Items.RemoveAt(i);
            }

            ar = 0;
            aux2 = 0;

            for (int i = 0; i <= count; i++)
            {
                aux[i] = 0;
            }
            count = 0;

            for (int i = 0; i <= count2; i++)
            {
                arreglo[i] = 0;
            }

            //variables para los costes finales
            count2 = 0;


            TE = 0;

            lbneto.Text = "";
            lbrecibi.Text = "";
            lbentregado.Text = "";
            lbfinal.Text = "";
            lbinicial.Text = "";
            lbdesc.Text = "";
            lbdias.Text = "";
            lbdescontada.Text = "";
            lbefectiva.Text = "";
            lbtcea.Text = "";

        }



        double CalculoTEPeriodo(double dias)
        {

            double n2 = 0;//tiempo en el que se expresa la tasa incialmente
                          //  double n1 = 0;//tiempo de capitalizacion de la tasa
            switch (cboPlazoTasa.SelectedIndex)
            {
                case 0:
                    n2 = 1;//diaria
                    break;
                case 1:
                    n2 = 15;//quincenal
                    break;
                case 2:
                    n2 = 30;//mensual
                    break;
                case 3:
                    n2 = 60;//bimestral
                    break;
                case 4:
                    n2 = 90;//trimestral
                    break;
                case 5:
                    n2 = 120;//cuatrimestral
                    break;
                case 6:
                    n2 = 180;//semestral
                    break;
                case 7:
                    n2 = 360;//anual
                    break; ;
            }

            double paso1 = (Convert.ToDouble(txtTasa.Text) / 100);
            double paso2 = (1 + (paso1));
            double paso3 = (Math.Pow(paso2, dias / n2) - 1) * 100;
            return (Math.Truncate(paso3 * 10000000) / 10000000);
        }
        double calculoTd(double te)
        {
            double num = te / 100;
            double tot = ((num) / (1 + num)) * 100;


            return (Math.Truncate(tot * 10000000) / 10000000);
        }
        double fdescuento(double d)
        {
            double des = Convert.ToDouble(txtNominal.Text) * (d / 100);
            return (Math.Truncate(des * 100) / 100);
        }

        double varNeto(double desc)
        {
            return Convert.ToDouble(txtNominal.Text) - desc;
        }


        double vaRecibido(double vn, double ci)
        {
            if (txtRetenciones.Text == "")
            {
                retencion = 0;
            }
            else
            {
                retencion = Convert.ToDouble(txtRetenciones.Text);
            }
            return vn - ci - retencion;
        }
        double vaEntregado(double cf)
        {
            if (txtRetenciones.Text == "")
            {
                retencion = 0;
            }
            else
            {
                retencion = Convert.ToDouble(txtRetenciones.Text);
            }
            return (Convert.ToDouble(txtNominal.Text)) + cf - retencion;
        }

        double tcea(double valr, double vale, double dias)
        {
            double nom = (vale / valr);
            double exp = (360 / dias);
            double fin = (Math.Pow(nom, exp) - 1) * 100;
            return (Math.Truncate(fin * 10000000) / 10000000);
        }


        //Este boton sirve para agregar un elemento a la lista (COSTES-INICIALES)
        private void button2_Click_1(object sender, EventArgs e)
        {
            //costesInciales+=Convert.ToDecimal(txtCostoInicial.Text);
            aux2 = Convert.ToDouble(txtCostoInicial.Text);
            aux[count] = aux2;
            lstInicial.Items.Add(cboInicial.Text + ": " + txtCostoInicial.Text);
            count++;
            txtCostoInicial.Clear();
        }


        //Este boton sirve para eliminar un elemento a la lista (COSTES-INICIALES)
        private void button4_Click(object sender, EventArgs e)
        {
            if (lstInicial.SelectedIndex > -1)
            {
                for (int i = 0; i <= count; i++)
                {
                    aux[lstInicial.SelectedIndex] = 0;
                }
                lstInicial.Items.Remove(lstInicial.SelectedItem);

            }
        }


        //Este boton sirve para agregar un elemento a la lista (COSTES-FINALES)

        private void button6_Click(object sender, EventArgs e)
        {
            ar = Convert.ToDouble(txtCostoFinal.Text);
            arreglo[count2] = ar;
            lstFinal.Items.Add(cboFinal.Text + ": " + txtCostoFinal.Text);
            count2++;
            txtCostoFinal.Clear();
        }

        //Este boton sirve para eliminar un elemento a la lista (COSTES-FINALES)
        private void button5_Click(object sender, EventArgs e)
        {
            if (lstFinal.SelectedIndex > -1)
            {
                for (int i = 0; i <= count2; i++)
                {
                    arreglo[lstFinal.SelectedIndex] = 0;
                }
                lstFinal.Items.Remove(lstFinal.SelectedItem);

            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < count; i++)
            {
                costesInciales += aux[i];
            }
            for (int i = 0; i <= count2; i++)
            {
                costesFinales += arreglo[i];
            }

            double dias = (Math.Truncate((double)(dateVencimiento.Value - dateDescuento.Value).TotalDays * 10) / 10);
            TE = CalculoTEPeriodo(dias);
            tasa = calculoTd(TE);
            descuento = fdescuento(tasa);
            valNeto = varNeto(descuento);
            entregado = vaEntregado(costesFinales);
            recibido = vaRecibido(valNeto, costesInciales);
            TCEA = tcea(recibido, entregado, dias);

            lbNominal.Text = txtNominal.Text;
            lbtcea.Text = TCEA.ToString();
            lbinicial.Text = costesInciales.ToString();
            lbfinal.Text = costesFinales.ToString();
            lbneto.Text = valNeto.ToString();
            lbdias.Text = dias.ToString();
            lbefectiva.Text = TE.ToString();
            lbdescontada.Text = tasa.ToString();
            lbdesc.Text = descuento.ToString();
            lbentregado.Text = entregado.ToString();
            lbrecibi.Text = recibido.ToString();

            tabControl1.SelectedTab = tabPage3;
        }

        private void btnVolverCosto1_Click(object sender, EventArgs e)
        {
            Restart();
            Menu frm = new Menu(username);
            frm.ShowDialog();
        }

        private void btnContinuarCostos1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
            tabControl1.SelectedTab = tabPage1;
        }
    }
}
