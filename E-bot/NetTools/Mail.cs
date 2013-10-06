using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

using ru.xnull.Config.Mapping.Net;
using log4net;
using ru.xnull.config;

namespace ru.xnull
{
    class Mail
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Mail));

        public static void Send(string subject, string body)
        {
            EmailMap emailMap = ConfigDao.Instance().configMap.netMap.emailMap;
            MailMessage mm = new MailMessage();
            mm.From = new System.Net.Mail.MailAddress(emailMap.from);
            mm.To.Add(new System.Net.Mail.MailAddress(emailMap.to));
            mm.Subject = subject.Replace("\n", " ").Replace("\r", " ");
            mm.IsBodyHtml = false;//письмо в html формате (если надо)
            mm.Body = body;
            SmtpClient client = new SmtpClient();
            client.Host = emailMap.server;
            client.Port = emailMap.port;
            client.Credentials = new NetworkCredential(emailMap.login, emailMap.pass);
            client.EnableSsl = false;
            if (ConfigDao.Instance().configMap.netMap.emailMap.usessl)
            {
                client.EnableSsl = true;
            }
            if (emailMap.sendmail)
            {
                try
                {
                    client.Send(mm);//поехало
                }
                catch (Exception err)
                {
                    log.Warn("Письмо не отправлено из за ошибки", err);
                }
            }

        }
    }
}