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
    public partial class IzmenaIBrisanjeRacuna : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public IzmenaIBrisanjeRacuna()
        {
            InitializeComponent();
            kki = new KontrolerKorisnickogInterfejsa.KontrolerKI();
        }

        private void IzmenaIBrisanjeRacuna_Load(object sender, EventArgs e)
        {
            kki.popuniPolja(cmbFrizer, cmbTip, cmbUsluga, txtUkIznos, dataGridView1, dateTimePicker1);
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.popuniComboUsluga(cmbUsluga, cmbTip);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.dodajStavku(cmbUsluga, txtUkIznos, txtBrojMin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kki.obrisiStavku(dataGridView1, txtUkIznos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kki.izmeniRacun(cmbFrizer,dateTimePicker1)) this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kki.obrisiRacun()) this.Close();
        }
    }
}
