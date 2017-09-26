using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Net.Mime;
using System.IO;
using System.Net;

namespace IMAP_Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetMail_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, k) => true;

                client.Connect("imap.mail.ru", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("elagin@citpb.ru", "6*2xoGRBBrqu");

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                var message = inbox.GetMessage(0);
                textBoxTheme.Text = message.Subject;
                textBoxTheme.Text += " Total messages: " + inbox.Count;


                foreach (var summary in inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure))
                {
                    if (summary.TextBody != null)
                    {
                        // this will download *just* the text/plain part
                        var text = inbox.GetBodyPart(summary.UniqueId, summary.TextBody);
                        byte[] binaryData = { 0 };
                       
                        string[] newText = text.ToString().Split('\n');
                        string unicodeString;
                        string end_text = "";

                        //  string buf = text.ToString().Replace("\n", ""); ;
                        //  string base64 = "base64";
                        //  string xxx = buf.Substring(buf.IndexOf(base64) + 6);

                        //     StreamReader strr = new StreamReader(HttpWebRequest.Create(@"http://api.foxtools.ru/v2/Base64.html?mode=Auto&text=CtCX0LTRgNCw0LLRgdGC0LLRg9C50YLQtSEK0JbQtNGDINC%2B0YLRh9C10YLQsCDQt9CwINCw0LLQ%0D%0As9GD0YHRgi4K0JfQtNC10YHRjCDRiNCw0LHQu9C%2B0L0g0L3QsCDRgdC10L3RgtGP0LHRgNGMLgoK%0D%0ACtChINGD0LLQsNC20LXQvdC40LXQvCwK0JDQu9C10LrRgdC10Lkg0J%2FQsNC90L7QsgrRgtC10Lsu%0D%0AICArNyAoOTAxKSA1MjYtMDEwMwpwYW5vdkBjaXRwYi5ydSDCoArQptC10L3RgtGAINCY0KIg0L%2FQ%0D%0AvtC00LTQtdGA0LbQutC4INCx0LjQt9C90LXRgdCwCtCT0LXQvdC10YDQsNC70YzQvdGL0Lkg0LTQ%0D%0AuNGA0LXQutGC0L7RgAo%3D&file=&url=&return=Text&lang=RU&cp=UTF-8&details=1").GetResponse().GetResponseStream());

                        //  StreamReader strr = new StreamReader(HttpWebRequest.Create(@"http://api.foxtools.ru/v2/Base64.html?mode=Auto&text=" + xxx + "&file=&url=&return=Text&lang=RU&cp=UTF-8&details=1").GetResponse().GetResponseStream()) ;

                        for (int i = 0; i <= newText.Count(); i++)
                        {
                            // Convert.FromBase64String(newText[i]);
                            try
                            {
                                binaryData = Convert.FromBase64String(newText[i]);
                                unicodeString = Encoding.UTF8.GetString(binaryData);
                                end_text += unicodeString.ToString();
                            }
                            catch
                            {
                                
                            }
                        }
                        // string buf2 = xxx[4].ToString();
                        //    binaryData = Convert.FromBase64String(text.ToString());


                        //  textBoxSubject.Text = "0 - " +  xxx[0].ToString()+ "\n 1 - " + xxx[1].ToString() + "\n 2 - " + xxx[2].ToString() + "\n 3 - " + xxx[3].ToString() + xxx[4].ToString(); 
                        textBoxSubject.Text = end_text;
                    }

                    if (summary.HtmlBody != null)
                    {
                        // this will download *just* the text/html part
                        var html = inbox.GetBodyPart(summary.UniqueId, summary.HtmlBody);                                                
                    }

                    // if you'd rather grab, say, an image attachment... it might look something like this:
                    if (summary.Body is BodyPartMultipart)
                    {
                        var multipart = (BodyPartMultipart)summary.Body;

                        var attachment = multipart.BodyParts.OfType<BodyPartBasic>().FirstOrDefault(x => x.FileName == "logo.jpg");
                        if (attachment != null)
                        {
                            // this will download *just* the attachment
                            var part = inbox.GetBodyPart(summary.UniqueId, attachment);
                          
                        }
                    }
                }

                //  Console.WriteLine("Total messages: {0}", inbox.Count);
                //  Console.WriteLine("Recent messages: {0}", inbox.Recent);

                //for (int i = 0; i < inbox.Count; i++)
                //{
                //    var message = inbox.GetMessage(i);
                //    Console.WriteLine("Subject: {0}", message.Subject);
                //}

                client.Disconnect(true);
            }
        }
    }
}
