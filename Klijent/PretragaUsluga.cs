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
    public partial class PretragaUsluga : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public PretragaUsluga()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void PretragaUsluga_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            kki.popuniComboTip(cmbTipUsluge);
        }

        private void cmbTipUsluge_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.pronadjiUsluge(cmbTipUsluge, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kki.izabriUslugu(dataGridView1)) 
            {
                new DetaljiUsluge().ShowDialog();
                cmbTipUsluge_SelectedIndexChanged(sender, e);
            }
        }

       
    }
}
