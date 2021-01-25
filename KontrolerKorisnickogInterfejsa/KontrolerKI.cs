using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KontrolerAplikacioneLogike;
using Biblioteka;
using System.Windows.Forms;

namespace KontrolerKorisnickogInterfejsa
{
    public class KontrolerKI
    {
        public static KontrolerAL kal;
        public static Usluga usluga;
        public static Racun racun;

        public static bool poveziSeNaServer()
        {
            kal = new KontrolerAL();
            return kal.poveziSeNaServer();
        }

        public void popuniComboTip(ComboBox cmbTip)
        {
            //cmbTip.DataSource = kal.vratiTipoveUsluga(new TipUsluge());

            foreach (TipUsluge tip in kal.vratiTipoveUsluga(new TipUsluge()))
            {
                cmbTip.Items.Add(tip);
            }
        }

        public void sacuvajUslugu(ComboBox cmbTip, TextBox txtCeena, TextBox txtNaziv, TextBox txtOpis)
        {
            Usluga u = new Usluga();
            u.TipUsluge = cmbTip.SelectedItem as TipUsluge;
            u.Naziv = txtNaziv.Text;
            u.Opis = txtOpis.Text;
            try
            {
                u.CenaPoMinutu = Convert.ToDouble(txtCeena.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Niste ispravno uneli cenu!");
                txtCeena.Clear();
                txtCeena.Focus();
                return;
            }

            Object rezultat = kal.sacuvajUslugu(u);

            if (rezultat == null || (int)rezultat == 0) MessageBox.Show("Usluga nije sacuvana!");
            else MessageBox.Show("Usluga je uspesno sacuvana!");
        }

        public void pronadjiUsluge(ComboBox cmbTip, DataGridView dataGridView1)
        {
            dataGridView1.Visible = false;
            Usluga u = new Usluga();
            u.TipUsluge = cmbTip.SelectedItem as TipUsluge;

            List<Usluga> lista = kal.vratiUsluge(u);

            if (lista == null || lista.Count == 0) MessageBox.Show("Ne postoje usluge za trazeni kriterijum!");
            else
            {
                dataGridView1.Visible = true;
                dataGridView1.DataSource = lista;
            }
        }

        public bool izabriUslugu(DataGridView dataGridView1)
        {
            try
            {
                usluga = dataGridView1.SelectedRows[0].DataBoundItem as Usluga;
                return true;
            }
            catch (Exception)
            {

                MessageBox.Show("Molimo vas izaberite uslugu za prikaz detalja!");
                return false;
            }
        }

        public void popuniPoljaUsluge(TextBox txtNaziv, TextBox txtOpis, TextBox txtTip, TextBox txtxCena)
        {
            txtNaziv.Text = usluga.Naziv;
            txtOpis.Text = usluga.Opis;
            txtxCena.Text = usluga.CenaPoMinutu.ToString();
            txtTip.Text = usluga.TipUsluge.ToString();
        }

        public bool izmeniUslugu(TextBox txtxCena)
        {
            try
            {
                usluga.CenaPoMinutu = Convert.ToDouble(txtxCena.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Niste ispravno uneli cenu!");
                txtxCena.Clear();
                txtxCena.Focus();
                return false;
            }

            Object rezultat = kal.izmeniUslugu(usluga);

            if (rezultat == null || (int)rezultat == 0) { MessageBox.Show("Izmena usluge nije sacuvana!"); return false; }
            else { MessageBox.Show("Izmena usluge je uspesno sacuvana!"); return true; }
        }

        public bool obrisiUslugu()
        {
            Object rezultat = kal.obrisiUslugu(usluga);

            if (rezultat == null || (int)rezultat == 0) { MessageBox.Show("Usluga nije obrisana!"); return false; }
            else { MessageBox.Show("Usluga je uspesno obrisana!"); return true; }

            //if (rezultat == null) { MessageBox.Show("Usluga nije obrisana!"); return false; }
            //else { MessageBox.Show("Usluga je uspesno obrisana!"); return true; }

            //Object o = kal.obrisiRacun(racun);
            //if (o == null)
            //{
            //    MessageBox.Show("Racun nije obrisan!");
            //    return false;
            //}
            //else
            //{
            //    MessageBox.Show("Racun je obrisan!");
            //    return true;
            //}
        }



        public void popuniCombo(ComboBox cmbFrizer, ComboBox cmbTip, DataGridView dataGridView1)
        {
           
            cmbFrizer.DataSource = kal.vratiSveFrizere();
            cmbTip.DataSource = kal.vratiTipoveUsluga(new TipUsluge());
            dataGridView1.DataSource = racun.ListaStavki;
        }

        public void popuniComboUsluga(ComboBox cmbUsluga, ComboBox cmbTip)
        {
            cmbUsluga.Text = "";
            Usluga u = new Usluga();
            u.TipUsluge = cmbTip.SelectedItem as TipUsluge;
            cmbUsluga.DataSource = kal.vratiUsluge(u);
        }

        public void dodajStavku(ComboBox cmbUsluga, TextBox txtUkIznos, TextBox txtBrMin)
        {
            StavkaRacuna sr = new StavkaRacuna();
            sr.Rb = racun.ListaStavki.Count + 1;
            sr.Usluga = cmbUsluga.SelectedItem as Usluga;
            try
            {
                sr.BrojMinuta = Convert.ToInt32(txtBrMin.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Minuti nisu ispravno uneti!");
                return;
            }
            try
            {
                sr.Cena = sr.Usluga.CenaPoMinutu * sr.BrojMinuta;
                racun.Iznos += sr.Cena;
                racun.ListaStavki.Add(sr);
                txtUkIznos.Text = racun.Iznos.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Stavka nije uneta!");
            }
        }

        public void obrisiStavku(DataGridView dataGridView1, TextBox txtUkIznos)
        {
            try
            {
                StavkaRacuna sr = dataGridView1.SelectedRows[0].DataBoundItem as StavkaRacuna;
                racun.ListaStavki.Remove(sr);
                racun.Iznos -= sr.Cena;
                txtUkIznos.Text = racun.Iznos.ToString();
                int i = 1;
                foreach (StavkaRacuna s in racun.ListaStavki)
                {
                    s.Rb = i;
                    i++;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Niste odabrali stavku!");
            }
        }

        public bool sacuvajRacun(ComboBox cmbFrizer, DateTimePicker dateTimePicker1)
        {
            racun.Frizer = cmbFrizer.SelectedItem as Frizer;

            if (racun.Frizer == null)
            {
                MessageBox.Show("Niste odabrali frizera!");
                return false;
            }

            if (racun.ListaStavki.Count < 1)
            {
                MessageBox.Show("Racun mora imati bar jednu stavku!");
                return false;
            }

            racun.DatumKreiranja = dateTimePicker1.Value;

            Object o = kal.unesiRacun(racun);
            if (o == null)
            {
                MessageBox.Show("Racun nije sacuvan!");
                return false;
            }
            else 
            {
                MessageBox.Show("Racun je sacuvan!");
                return true;
            }
        }

        public void popuniComboFrizer(ComboBox cmbFrizer)
        {
            cmbFrizer.DataSource = kal.vratiSveFrizere();
        }

        public void prikaziRacune(ComboBox cmbFrizer, GroupBox groupBox1, DataGridView dataGridView1)
        {
            groupBox1.Visible = false;
            racun = new Racun();
            racun.Frizer = cmbFrizer.SelectedItem as Frizer;
            List<Racun> lista = kal.pretraziRacune(racun);
            if (lista == null||lista.Count==0)
            {
                MessageBox.Show("Nema racuna za izabranog frizera!");
            }
            else 
            {
                dataGridView1.DataSource = lista;
                groupBox1.Visible = true;
            }
        }

        public void kreirajRacun()
        {
            racun = new Racun();
        }

        public void popuniPolja(ComboBox cmbFrizer, ComboBox cmbTip, ComboBox cmbUsluga, TextBox txtUkIznos, DataGridView dataGridView1, DateTimePicker dateTimePicker1)
        {
            
            cmbFrizer.DataSource = kal.vratiSveFrizere();
            cmbTip.DataSource = kal.vratiTipoveUsluga(new TipUsluge());
            dataGridView1.DataSource = racun.ListaStavki;
            cmbFrizer.Text = racun.Frizer.ToString();
            dateTimePicker1.Value = racun.DatumKreiranja;
            txtUkIznos.Text = racun.Iznos.ToString();
        }

       

        public bool obrisiRacun()
        {
            Object o = kal.obrisiRacun(racun);
            if (o == null)
            {
                MessageBox.Show("Racun nije obrisan!");
                return false;
            }
            else
            {
                MessageBox.Show("Racun je obrisan!");
                return true;
            }
        }

        public bool izmeniRacun(ComboBox cmbFrizer, DateTimePicker dateTimePicker1)
        {
            racun.Frizer = cmbFrizer.SelectedItem as Frizer;
            racun.DatumKreiranja = dateTimePicker1.Value;

            if (racun.Frizer == null)
            {
                MessageBox.Show("Niste odabrali frizera!");
                return false;
            }

            if (racun.ListaStavki.Count < 1)
            {
                MessageBox.Show("Racun mora imati bar jednu stavku!");
                return false;
            }

            Object o = kal.izmeniRacun(racun);
            if (o == null)
            {
                MessageBox.Show("Racun nije izmenjen!");
                return false;
            }
            else
            {
                MessageBox.Show("Racun je izmenjen!");
                return true;
            }
        }

        public bool prikaziDetalje(DataGridView dataGridView1)
        {
            try
            {
                racun = dataGridView1.SelectedRows[0].DataBoundItem as Racun;
                return true;
            }
            catch (Exception)
            {

                MessageBox.Show("Niste izabrali racun!");
                return false;
            }
        }
    }
}
