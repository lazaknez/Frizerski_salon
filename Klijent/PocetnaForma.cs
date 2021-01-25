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
    public partial class PocetnaForma : Form
    {
        
        public PocetnaForma()
        {
            
            InitializeComponent();
            if(KontrolerKI.poveziSeNaServer()) this.Text="Uspesno povezan!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosUsluge().ShowDialog();
        }

        private void pretragaUslugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PretragaUsluga().ShowDialog();
        }

        private void unosRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosRacuna().ShowDialog();
        }

        private void pregledRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PregledRacuna().ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
