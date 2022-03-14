using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Baza;
using Prijava;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Nikola Muše
    /// </summary>
    public partial class Profil : Form
    {
        public Autentifikator Autentifikator { get; set; }
        public PictureBox Profilna { get; set; }
        string extension = "";
        public Profil()
        {
            InitializeComponent();
        }

        public Profil(Autentifikator autentifikator,PictureBox slikaProfilne)
        {
            InitializeComponent();
            Autentifikator = autentifikator;
            Profilna = slikaProfilne;
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
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
                btnSpremi.Enabled = true;
            }
            catch (Exception)
            {

                //MessageBox.Show("Slika nije odabrana!");
            }
           
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            /*
            MemoryStream ms = new MemoryStream();
            var photo = pictureBox1.Image;
            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            DB.Instance.IzvrsiUpit($"INSERT INTO slike (slika) VALUES ('{ms.ToArray()}');");
            */
            MemoryStream ms = new MemoryStream();
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
            
            
            var parameters = new Dictionary<string, object>();
            parameters.Add("@slika", ms.ToArray());
            parameters.Add("@korime", Autentifikator.AktivanKorisnik);
            //DB.Instance.ExecuteParamQuery("INSERT INTO [Slika_test] ([slika]) VALUES (@slika);", parameters);

            DB.Instance.ExecuteParamQuery("UPDATE [korisnici] SET [slika] = (@slika) WHERE [korisnicko_ime] = (@korime);", parameters);
            Profilna.Visible = true;
            Profilna.Image = photo;
            Close();
        }


        private void Profil_Load(object sender, EventArgs e)
        {
            /*
            string sqlupit = $"SELECT * FROM Slika_test";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlupit);
            while (dr.Read())
            {
                if (dr["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])dr["slika"]);
                    Image image=Image.FromStream(ms);
                }
            }
            */
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            //var rezultat = DB.Instance.DohvatiDataReader("SELECT * FROM Slika_test;");A}
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM korisnici WHERE korisnicko_ime='{Autentifikator.AktivanKorisnik}';");
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
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            rezultat.Close();
            btnSpremi.Enabled = false;
            /*
            foreach (var item in rezultat)
            {
                MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                Image image = Image.FromStream(ms);
                //noviArtikl.Slika = Image.FromStream(ms);
            }
            */
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            Korisnik korisnik = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika(Autentifikator.AktivanKorisnik));
            if (form != null)
                form.openChildForm(new NoviKorisnik(korisnik,Autentifikator));
        }
    }
}
