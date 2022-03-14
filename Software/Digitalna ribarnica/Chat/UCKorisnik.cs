using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;

namespace Chat
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class UCKorisnik : UserControl
    {

        private User Korisnik = null;
        Iform Iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public int IDkorisnika { get; set; }
        public UCKorisnik(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
        }

        /// <summary>
        /// Metoda koja UCKorisnik dodijeljuje svojstva
        /// </summary>
        /// <param name="korisnik"></param>
        public void LoadPonuda(User korisnik)
        {
            this.Korisnik = korisnik;
        }
        /// <summary>
        /// Zatvaranje trenutne forme te otvaranje nove forme u panelu
        /// </summary>
        /// <param name="childForm">Trenutno aktivna forma koja će se zatvoriti</param>
        public void openChildForm(Form childForm)
        {
            if (Trenutna != null)
                Trenutna.Close();
            Trenutna = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelStranice.Controls.Add(childForm);
            panelStranice.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            
            Chat form = Application.OpenForms.OfType<Chat>().FirstOrDefault();
            if (form != null)
            {
                form.PrikaziPorukue(IDkorisnika);
            }
            
        }
    }
}
