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
    public partial class PregledRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public PregledRacuna()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void PregledRacuna_Load(object sender, EventArgs e)
        {
            kki.popuniComboFrizer(cmbFrizer);
        }

        private void cmbFrizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.prikaziRacune(cmbFrizer, groupBox1, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kki.prikaziDetalje(dataGridView1)) 
            {
                new IzmenaIBrisanjeRacuna().ShowDialog();
                cmbFrizer_SelectedIndexChanged(sender, e);
            }
        }
    }
}
