using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KontrolerKorisnickogInterfejsa;

namespace Klijent
{
    public partial class UnosUsluge : Form
    {
        KontrolerKI kki;
        public UnosUsluge()
        {
            InitializeComponent();
            kki = new KontrolerKI();
        }

        private void UnosUsluge_Load(object sender, EventArgs e)
        {
            kki.popuniComboTip(cmbTip);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kki.sacuvajUslugu(cmbTip, txtCeena, txtNaziv, txtOpis);
            this.Close();
        }
    }
}
