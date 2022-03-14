using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lokacije;
using RibeUSustavu;
using Baza;
using INSform;
using Prijava;
using System.Data.SqlClient;
using Ponude;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class DodajPonudu : Form
    {
        string extension = "";
        Iform iform;
        public DodajPonudu(Iform nova)
        {
            InitializeComponent();
            iform = nova;
        }

        private void DodajPonudu_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox1.Visible = false;
            btnUcitaj.Visible = false;
            /*
            cmbLokacija.DataSource = LokacijeRepozitory.dohvatiLokacije();
            cmbRiba.DataSource = RibeRepository.DohvatiNaziveRibe();
            */
            List<Riba> ribe = new List<Riba>();
            ribe = RibeRepository.DohvatiNaziveRibe();
            List<Riba> sortiraneRibe = ribe.OrderBy(o => o.Naziv).ToList();
            List<Lokacije.Lokacije> lokacije = new List<Lokacije.Lokacije>();
            lokacije = LokacijeRepozitory.dohvatiLokacije();
            List<Lokacije.Lokacije> sortiraneLokacije = lokacije.OrderBy(o => o.Naziv).ToList();
            cmbRiba.DataSource = sortiraneRibe;
            cmbLokacija.DataSource = sortiraneLokacije;
            Riba riba = cmbRiba.SelectedValue as Riba;
            lblMjerna.Text = riba.MjernaJedinica;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                pictureBox1.Visible = true;
                btnUcitaj.Visible = true;
                btnKreiraj.Enabled = false;
            }
            else
            {
                pictureBox1.Visible = false;
                btnUcitaj.Visible = false;
                btnKreiraj.Enabled = true;
            }
        }

        private void cmbRiba_SelectedIndexChanged(object sender, EventArgs e)
        {
            Riba riba = cmbRiba.SelectedValue as Riba;
            lblMjerna.Text = riba.MjernaJedinica;
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "images|*.png;*.jpg;*jpeg";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.CheckFileExists)
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                }
                extension = Path.GetExtension(openFileDialog1.FileName);
                btnKreiraj.Enabled = true;
            }
            catch (Exception)
            {

                //MessageBox.Show("Slika nije odabrana!");
            }
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            var photo = pictureBox1.Image;
            PredefiniranePostavke predefiniranePostavke = new PredefiniranePostavke();
            predefiniranePostavke = PonudeRepozitory.PredefiniranePostavke();
            var parameters = new Dictionary<string, object>();
            if (float.TryParse(txtCijena.Text, out float cijena))
            {
                if (cijena >= predefiniranePostavke.Cijena)
                    parameters.Add("@cijena", cijena);
                else
                {
                    MessageBox.Show("Minimalna cijena iznosi " + predefiniranePostavke.Cijena);
                    notifyPonuda.ShowBalloonTip(1000, "Krivo unesena cijena", "Minimalna cijena iznosi " + predefiniranePostavke.Cijena, ToolTipIcon.Warning);
                    return;
                }
            }
            else
                MessageBox.Show("Niste unije broj kod cijene");

            if (int.TryParse(txtKolicina.Text, out int kolicina))
            {
                if (kolicina >= predefiniranePostavke.Kolicina)
                    parameters.Add("@kolicina", kolicina);
                else
                {
                    MessageBox.Show("Minimalna količina iznosi " + predefiniranePostavke.Kolicina);
                    notifyPonuda.ShowBalloonTip(1000, "Krivo unesena količina", "Minimalna količina iznosi " + predefiniranePostavke.Kolicina, ToolTipIcon.Warning);
                    return;
                }
            }
            else
                MessageBox.Show("Niste unijeli broj kod količine");

            parameters.Add("@opis", rtbxOpis.Text);
            if(int.TryParse(txtSati.Text, out int sati))
                parameters.Add("@sati", sati);
            else
                MessageBox.Show("Niste unijeli broj kod sati");
            if (extension != "")
            {
                switch (extension)
                {
                    case ".jpeg":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        break;
                    case ".jpg":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        break;
                    case ".png":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        break;
                    default:
                        MessageBox.Show("Format nije podržan!");
                        break;
                }
                parameters.Add("@slika", ms.ToArray());
            }
            parameters.Add("@idriba", (cmbRiba.SelectedValue as Riba).id);
            parameters.Add("@idlokacija", (cmbLokacija.SelectedValue as Lokacije.Lokacije).id);
            parameters.Add("@idkorisnika", KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik));



            if ((float.TryParse(txtCijena.Text, out float cijena2)) && (int.TryParse(txtKolicina.Text, out int kolicina2)) && (int.TryParse(txtSati.Text, out int sati2))) 
            {
                //DB.Instance.ExecuteParamQuery("INSERT INTO [Slika_test] ([slika]) VALUES (@slika);", parameters);
                if (extension != "")
                    DB.Instance.ExecuteParamQuery("INSERT INTO [ponude]([cijena], [kolicina], [opis], [trajanje_rezervacije_u_satima], [dodatna_fotografija], [id_riba], [id_lokacija], [id_korisnik]) VALUES((@cijena), (@kolicina), (@opis), (@sati), (@slika), (@idriba), (@idlokacija), (@idkorisnika)); ", parameters);
                else
                    DB.Instance.ExecuteParamQuery("INSERT INTO [ponude]([cijena], [kolicina], [opis], [trajanje_rezervacije_u_satima], [id_riba], [id_lokacija], [id_korisnik]) VALUES((@cijena), (@kolicina), (@opis), (@sati), (@idriba), (@idlokacija), (@idkorisnika)); ", parameters);
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je kreirao ponudu ribe: "+cmbRiba.SelectedItem, 4);
                notifyPonuda.ShowBalloonTip(1000, "Kreiranje ponude", "Uspješno ste kreirali ponudu", ToolTipIcon.Info);
                formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                if (form != null)
                    form.zatvoriForme();
                Close();
            }

            
        }
    }
}
