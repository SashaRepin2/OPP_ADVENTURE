using UnityEngine;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Globalization;

public class SendingProgress : MonoBehaviour
{


    public InputField toMail;

    public Button sendBtn;

    private static string Tr2(string s)
    {
        StringBuilder ret = new StringBuilder();
        string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
          "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",
          "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я"," "};
        string[] eng = { "A", "B", "V", "G", "D", "E", "E", "ZH", "Z", "I", "Y",
          "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "KH", "TS",
          "CH", "SH", "SHCH", null, "Y", null, "E", "YU", "YA"," "};

        for (int j = 0; j < s.Length; j++)
            for (int i = 0; i < rus.Length; i++)
                if (s.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
        return ret.ToString();
    }//метод для написания имени транслитом, так как iTextSharp поддерживает только латиницу

    public void Download()
    {

        var doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream(Application.persistentDataPath + "/Document.pdf", FileMode.Create));//у меня он сохраняет документ по пути Android/data/com.DefailtCompany.com.unity.../files, 
        //если нужно потестить без сборки, в окошке unity, то пиши Application.dataPath, тогда он будет сохранять файл в Assets 

        doc.Open();
        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //persistentDataPath

        //BaseFont bfR = BaseFont.CreateFont(Application.dataPath+"/fonts/18683.ttf", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
        iTextSharp.text.BaseColor clrBlue = new iTextSharp.text.BaseColor(0, 0, 128);

        iTextSharp.text.Font title = new iTextSharp.text.Font(bf, 44, iTextSharp.text.Font.NORMAL, clrBlue);

        Paragraph p0 = new Paragraph(new Chunk("OOP Adventure", title));
        p0.Alignment = Element.ALIGN_CENTER;
        doc.Add(p0);

        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.NORMAL);

        Paragraph p1 = new Paragraph(new Chunk(Tr2(AuthManager.USER_NAME) + " from " + AuthManager.USER_GROUP + " completed the game on " + ProgressValues.GameProgress.ToString() + '%', font));
        p1.Alignment = Element.ALIGN_CENTER;
        doc.Add(p1);


        Paragraph p2 = new Paragraph("\nProgress in chapter <Encapsulation> - " + ProgressValues.FirstPartProgress.ToString() + "%"
           + "\nProgress in chapter <Inheritance> - " + ProgressValues.SecondPartProgress.ToString() + "%"
           + "\nProgress in chapter <Polymorphism> - " + ProgressValues.ThirdPartProgress.ToString() + "%"
           + "\nProgress in chapter <Abstraction> - " + ProgressValues.FourthPartProgress.ToString() + "%", font);
        doc.Add(p2);


        doc.Close();

    }

    public void SendClick()
    {
        try
        {
            //toMail.text.ToString() == "" || (!toMail.text.ToString().Contains("@"))
            if (!IsValidEmail(toMail.text))
            {
                // Выводи сообщения об ошибке пользователю
                MessageController messageController = FindObjectOfType<MessageController>();
                messageController.ShowMessage("Ошибка!", "Почта введена не правильно.", MessageController.TypeMessage.Error, 15);
                Debug.Log("Почта не введена");
            }
            else
            {
                Download();//создаём файл

                MailAddress fromAddress = new MailAddress("OOP.Adventure.Postman@gmail.com", "Postman");//почта с которой отправлять

                MailAddress toAddress = new MailAddress(toMail.text.ToString());//почта на которую отправлять

                MailMessage message = new MailMessage(fromAddress, toAddress);


                message.Body = "Report from " + AuthManager.USER_NAME + " " + AuthManager.USER_GROUP;
                message.Subject = "OOP Adventure";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromAddress.Address, "OOP.Adventure.Postman223");

                try
                {
                    message.Attachments.Add(new Attachment(Application.persistentDataPath + "/Document.pdf"));//достаёт pdf из корневой папки и прикрепляет к письму
                }
                catch (FileNotFoundException e)
                {
                    Debug.Log("Файл не найден\n" + e.ToString());
                    return;
                }
                smtpClient.Send(message);

                // Выводи сообщения об ошибке пользователю
                MessageController messageController = FindObjectOfType<MessageController>();
                messageController.ShowMessage("Успешно!", "Результат был отправлен на почту.", MessageController.TypeMessage.Error, 15);
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Error:" + ex);
        }
    }


    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }


}
