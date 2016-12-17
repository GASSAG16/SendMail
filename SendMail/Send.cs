using System;
using System.Net;
using System.Net.Mail;
	


namespace SendMail
{
    public class Send
    {
        string _fromMail, _toMail, _subjectMail, _bodyMail;
     
        string _key;

        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <param name="fromMail">Почта отправителя</param>
        /// <param name="toMail">Почта получателя</param>
        /// <param name="subjectMail">Тема письма</param>
        /// <param name="bodyMail">Тело письма</param>
        public void sendMail(string fromMail, string toMail, string subjectMail, string bodyMail,string keyMail)
        {
            _fromMail = fromMail;
            _toMail = toMail;
            _subjectMail = subjectMail;
            _bodyMail = bodyMail;
            _key = keyMail;
            send();
        }

        private void send()
        {
            try
            {
                using (MailMessage mailmessage = new MailMessage(_fromMail, _toMail))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    mailmessage.Subject = _subjectMail;
                    mailmessage.Body = _bodyMail;

                    smtpClient.Host = "smtp.mail.ru";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_fromMail, _key);
                    smtpClient.Send(mailmessage);
                    System.Windows.Forms.MessageBox.Show("Ваше письмо отправлено!", "Информация!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Внимательно проверьте данные!","Ошибка!!!",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            }

        }
    }
}
