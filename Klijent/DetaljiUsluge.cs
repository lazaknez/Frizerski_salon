using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Klijent
{
    public partial class DetaljiUsluge : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public DetaljiUsluge()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void DetaljiUsluge_Load(object sender, EventArgs e)
        {
            kki.popuniPoljaUsluge(txtNaziv, txtOpis, txtTip, txtxCena);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kki.izmeniUslugu(txtxCena))
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Jeste li sigurni da zelite da obrisete uslugu? ","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ;
            switch (dialog)
            {
               
                case DialogResult.Yes:
                    if (kki.obrisiUslugu())
                    {
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
           
        }
    }
}
