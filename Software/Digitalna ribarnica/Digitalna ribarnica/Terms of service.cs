using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Terms_of_service : Form
    {
        public bool Prihvaceni;
        public Terms_of_service(bool prihvaceniuvjeti)
        {
            InitializeComponent();
            Prihvaceni = prihvaceniuvjeti;
        }

        private void Terms_of_service_Load(object sender, EventArgs e)
        {
            
            richTerms.BackColor = Color.Gray;
            string naslov = "THIS AGREEMENT HAS A PROVISION FOR ARBITRATION OF DISPUTES BETWEEN THE PARTIES. PLEASE READ THE ENTIRE AGREEMENT IN DETAIL.";
            string tijelo=  "\n\nThis Registration Agreement(\"Agreement\") sets forth the terms and conditions of your use of domain name registration and related services sold via Name.com and its related platforms(\"Services\")." +
                "In this Agreement \"you\" and \"your\" refer to you and the registrant listed in the WHOIS/ Registration Data Directory Service(“RDDS”) contact information for the domain name. \"We\", \"us\" and \"our\" refer to the registrars listed at the bottom of this document, " +
                "any one of which will be the registrar for your domain name and all of which share common ownership, common terms and conditions, and a shared Services infrastructure.To determine which registrar your domain name is registered with, perform a RDDS lookup at our RDDS lookup.\n\nYOUR AGREEMENT:\n"+
                "By using the Services, you agree to all terms and conditions of this Agreement, the UDRP(defined below), the URS(defined below), and any rules, policies, or agreements published in association with specific Services and / or which may be adopted or enforced by the Internet Corporation for Assigned"+
                " Names and Numbers(\"ICANN\"), any registry, agency, or governments."+
                "\n\n\nCHANGES TO THIS AGREEMENT:"+
                "\nThis Agreement may change over time, either through amendments by us, changes to ICANN policy or applicable law which may or may not be reflected in the text of this Agreement, or otherwise.Before any material changes to this Agreement become binding on you(other than changes resulting from a change in ICANN policy or applicable law), " +
                "we will notify you of such changes by, for example, sending you an email to the email address of record.If, as a result of such a change, you no longer agree with the terms of this Agreement, your exclusive remedies are(a) to transfer your domain name registration services to another registrar, or(b) to cancel your Services, including domain" +
                " name registration services, with us.Your continued use of the Services following notification of a change in this Agreement indicates your consent to the changes.Unless otherwise specified by us, any such change binds you: (1) thirty(30) days after we notify you of the change, or(2) immediately if such change is a result of a new or amended " +
                "ICANN policy or applicable law.";
            richTerms.Text += naslov;
            richTerms.SelectAll();
            richTerms.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
            richTerms.Select(0, 0);
            richTerms.Text += tijelo;
            richTerms.Select(naslov.Length, tijelo.Length);
            richTerms.SelectionFont = new Font("Times New Roman", 14, FontStyle.Regular);
            richTerms.Select(0, 0);
            richTerms.Enabled = true;
            richTerms.ReadOnly = true;
        }

        private void buttonPrihvacam_Click(object sender, EventArgs e)
        {
            Prihvaceni = true;
            Close();
        }

        private void buttonOdbijam_Click(object sender, EventArgs e)
        {
            Prihvaceni = false;
            Close();
        }
    }
}
