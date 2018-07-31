    using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Security.Cryptography;
public class SendEmail
{
    MailMessage mail;
    NetworkCredential mailAuthentication;
    static string FromID = "dakshjn994@gmail.com";                // ENTER FROM EMAIL ID
    static string pwd = "IAM4111198i@m";                             // PASSWORD

    public void sendEMail(string ToEmail, string msg,string path)
    {
        mail = new MailMessage(FromID, ToEmail, "Vallabh Innovation",  msg);
        Attachment attachment;
        attachment = new Attachment(path);
        mail.Attachments.Add(attachment);
        mailAuthentication = new NetworkCredential(FromID,  pwd);
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.EnableSsl = true;
        mailClient.Credentials = mailAuthentication;
        mail.IsBodyHtml = true;
        mailClient.Send(mail);
    }
    
}