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
using RibeUSustavu;
using Baza;
using System.Data.Common;
using INSform;
using Ponude;
using Prijava;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class DodajRibu : Form
    {
        string extension;
        Riba Riba;
        Image defaultSlika;
        Iform Iform;
        public DodajRibu(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
        }

        public DodajRibu(Riba riba, Iform novo)
        {
            InitializeComponent();
            Riba = riba;
            Iform = novo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                notifyRiba.ShowBalloonTip(1000, "Ribe u sustavu", "Odustali ste od dodavanja/ažuriranja ribe", ToolTipIcon.Info);
                form.openChildForm(new RibeUSustavu(Iform));
            }
            Close();
        }

        private void BtnDodajSliku_Click(object sender, EventArgs e)
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
            }
            catch (Exception)
            {

                //MessageBox.Show("Slika nije odabrana!");
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            if (extension != "")
            {
                var photo = pictureBox1.Image;
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
            }
   
            if (Riba != null)
            {
                var parametersAzuriranje = new Dictionary<string, object>();
                parametersAzuriranje.Add("@naziv", textBox1.Text);
                if (extension != "")
                    parametersAzuriranje.Add("@slika", ms.ToArray());
                else {
                    var staraSlika = Riba.SlikaRibe;
                    try
                    {
                        staraSlika.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            staraSlika.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (Exception)
                        {

                        }
                    }
                  
                    parametersAzuriranje.Add("@slika", ms.ToArray());
                }
                if (radioButton1.Checked == true)
                    parametersAzuriranje.Add("@mjerna_jedinica", 0);
                else if (radioButton2.Checked == true)
                    parametersAzuriranje.Add("@mjerna_jedinica", 1);
                parametersAzuriranje.Add("@id_riba", Riba.id);
                RibeRepository.AzurirajRibu(parametersAzuriranje);
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je ažurirao ribu: " + textBox1.Text +" s ID-om "+Riba.id, 17);
                notifyRiba.ShowBalloonTip(1000, "Ribe u sustavu", "Uspješno ste ažurirali ribu!", ToolTipIcon.Info);
            }
            else
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("@naziv", textBox1.Text);
                if(extension!="")
                    parameters.Add("@slika", ms.ToArray());
                else
                {
                    dohhvatiDefaultSliku();
                    try
                    {
                        defaultSlika.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            defaultSlika.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    parameters.Add("@slika", ms.ToArray());
                }
                if (radioButton1.Checked == true)
                    parameters.Add("@mjerna_jedinica", 0);
                else if (radioButton2.Checked == true)
                    parameters.Add("@mjerna_jedinica", 1);
                RibeRepository.DodajNovuRibu(parameters);
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je dodao novu ribu: "+ textBox1.Text, 16);
                notifyRiba.ShowBalloonTip(1000, "Ribe u sustavu", "Uspješno ste dodali ribu!", ToolTipIcon.Info);
            }
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new RibeUSustavu(Iform));
            }
            Close();
        }
        /// <summary>
        /// Metoda koja dohvaća defaultnu sliku ribe iz baze
        /// </summary>
        public void dohhvatiDefaultSliku()
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM slikeRiba;");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }

            foreach (var item in returnMe)
            {
                if (item["slika"].ToString() != "")
                {
                    MemoryStream drugi = new MemoryStream((byte[])item["slika"]);
                    defaultSlika = Image.FromStream(drugi);

                }
            }
            rezultat.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                radioButton1.Checked = false;
        }

        private void DodajRibu_Load(object sender, EventArgs e)
        {
            extension = "";
            if (Riba != null)
            {
                pictureBox1.Image = Riba.SlikaRibe;
                textBox1.Text = Riba.Naziv;
                if (Riba.MjernaJedinica == "kom")
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
            }
        }


    }
}
