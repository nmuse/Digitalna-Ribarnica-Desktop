using Microsoft.Reporting.WinForms;
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
using Prijava;
namespace Ponude
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Izvjesce : Form
    {
        List<string> mailovi = new List<string>();
        Korisnik Kupac = new Korisnik();
        Korisnik Ponuditelj = new Korisnik();
        Zahtjev Zahtjev;
        PonudeIzvjesca Ponuda;
        public Izvjesce(List<string> dobiveni, Korisnik kupac, Korisnik ponuditelj,Zahtjev zahtjev)
        {
            InitializeComponent();
            this.Hide();
            mailovi = dobiveni;
            Kupac = kupac;
            Ponuditelj = ponuditelj;
            Zahtjev = zahtjev;
            Ponuda = PonudeRepozitory.DohvatiPonuduIzvjesca(Zahtjev.IDPONUDE);
        }

        private void Izvjesce_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("VrijemeRezervacije", DateTime.Now.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("EmailKupca", mailovi.Last()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("EmailPonuditelja", mailovi.First()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ImeKupca", Kupac.Ime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("PrezimeKupca", Kupac.Prezime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("TelefonKupac", Kupac.BrojMobitela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ImePonuditelja", Ponuditelj.Ime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("PrezimePonuditelja", Ponuditelj.Prezime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("TelefonPonuditelj", Ponuditelj.BrojMobitela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("RezervacijaVrijedi", DateTime.Now.AddHours(double.Parse(Zahtjev.BrojSatiDana)).ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Kolicina", Zahtjev.Kolicina.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Mjerna", Ponuda.mjerna));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Naziv", Ponuda.naziv));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cijena", Ponuda.cijena.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Ukupno", (double.Parse(Ponuda.cijena.ToString())*double.Parse(Zahtjev.Kolicina.ToString())).ToString()));
            this.Hide();
            this.reportViewer1.RefreshReport();
            Mail mail = new Mail(mailovi);
            mail.Text = "Poštovani,\nu prilogu Vam dostavljamo rezervaciju.\nLijep pozdrav i nadamo se ugodnoj daljnoj suradnji!";
            mail.Title = "Odobrena rezervacija ribe";
            mail.AttachmentFiles.Add(ExportReportToPDF("Rezervacija.pdf"));
            mail.DeleteFilesAfterSend = true;
            mail.RequireAutentication = true;
            mail.Send();
        }

        /// <summary>
        /// Metoda koja pretvara Report u pdf
        /// </summary>
        /// <param name="reportName">Naziv pdf-a</param>
        /// <returns></returns>
        private string ExportReportToPDF(string reportName)
        {
            string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>8.27in</PageWidth>" +
                    "  <PageHeight>11.69in</PageHeight>" +
                    "  <MarginTop>0.25in</MarginTop>" +
                    "  <MarginLeft>0.4in</MarginLeft>" +
                    "  <MarginRight>0in</MarginRight>" +
                    "  <MarginBottom>0.25in</MarginBottom>" +
                    "  <EmbedFonts>None</EmbedFonts>" +
                    "</DeviceInfo>";
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = reportViewer1.LocalReport.Render(
               "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            string filename = Path.Combine(Path.GetTempPath(), reportName);
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            return filename;
        }
    }
}
