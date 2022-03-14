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
namespace Ocjene
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class UCOcjena : UserControl
    {
        private Ocjena ocjena = null;
        INSform.Iform Iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public float Prosjek { get; set; }
        public UCOcjena(INSform.Iform nova)
        {
            InitializeComponent();
            Iform = nova;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }
        /// <summary>
        /// Metoda koja UCOcjena dodijeljuje svojstva
        /// </summary>
        /// <param name="ocjena"></param>
        public void LoadPonuda(Ocjena ocjena)
        {
            this.ocjena = ocjena;
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
    }
}
