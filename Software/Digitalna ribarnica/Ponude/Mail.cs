using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace Ponude
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class Mail
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
        public bool RequireAutentication { get; set; }
        public bool DeleteFilesAfterSend { get; set; }

        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public List<string> AttachmentFiles { get; set; }

        #region appi declarations

        internal enum MoveFileFlags
        {
            MOVEFILE_REPLACE_EXISTING = 1,
            MOVEFILE_COPY_ALLOWED = 2,
            MOVEFILE_DELAY_UNTIL_REBOOT = 4,
            MOVEFILE_WRITE_THROUGH = 8
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool MoveFileEx(string lpExistingFileName,
                                      string lpNewFileName,
                                      MoveFileFlags dwFlags);

        #endregion

        public Mail(List<string> mailovi)
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
            AttachmentFiles = new List<string>();
            From = MailConfig.Username;
            To = mailovi;
        }
        /// <summary>
        /// Metoda koja šalje mail
        /// </summary>
        public void Send()
        {
            var client = new SmtpClient
            {
                Host = MailConfig.Host,
                Port = 587,
                EnableSsl = true
            };

            if (RequireAutentication)
            {
                var credentials = new NetworkCredential(MailConfig.Username,
                                                        MailConfig.Password);
                client.Credentials = credentials;
            }

            var message = new MailMessage
            {
                Sender = new MailAddress(From, From),
                From = new MailAddress(From, From)
            };

            AddDestinataryToList(To, message.To);
            AddDestinataryToList(Cc, message.CC);
            AddDestinataryToList(Bcc, message.Bcc);

            message.Subject = Title;
            message.Body = Text;
            message.IsBodyHtml = false;
            message.Priority = MailPriority.High;

            var attachments = AttachmentFiles.Select(file => new Attachment(file));
            foreach (var attachment in attachments)
                message.Attachments.Add(attachment);

            client.Send(message);

            if (DeleteFilesAfterSend)
                AttachmentFiles.ForEach(DeleteFile);
        }
        /// <summary>
        /// Metoda koja dodaje listu mailova 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="mailAddressCollection"></param>
        private void AddDestinataryToList(IEnumerable<string> from,
           ICollection<MailAddress> mailAddressCollection)
        {
            foreach (var destinatary in from)
                mailAddressCollection.Add(new MailAddress(destinatary, destinatary));
        }
        /// <summary>
        /// Metoda koja briše fileove (pdf) u sljedećem REBOOTU
        /// </summary>
        /// <param name="filepath"></param>
        private void DeleteFile(string filepath)
        {
            MoveFileEx(filepath, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
        }
    }
}
