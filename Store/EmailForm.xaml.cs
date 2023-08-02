using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Store.CustomerOrderDSTableAdapters;

namespace Store
{
    /// <summary>
    /// Interaction logic for EmailForm.xaml
    /// </summary>
    public partial class EmailForm : Window
    {
        public EmailForm()
        {
            InitializeComponent();
        }

        private void Btn_Send_Click(object sender, RoutedEventArgs e)
        {
            CustomerTableAdapter customerTableAdapter = new CustomerTableAdapter();
            

            string from ="Danielgold5618@gmail.com";
            int customerId = int.Parse(Txt_To.Text);//לקבל  מעמודה  ערך הזה
            string to = customerTableAdapter.selectEmailByCustomerId(customerId).ToString().Trim(); // צריך להיות באמצעות selectEmailById
            string subject = Txt_Subject.Text;
            string body = Txt_Body.Text;
            string mailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            bool isValidRecipient = Regex.IsMatch(to, mailPattern);
           
            
            
          
            if (!isValidRecipient)
            {
                MessageBox.Show("The recipient's email address is not valid!", "Error");
            }
            else if (from == "" || to == "" || subject == "" || body == "")
            {
                MessageBox.Show("One or more fields are empty!", "Unable to send");
            }
            else
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = body;
                string password = "dxzfdvdjhygbtuqh"; //the password i got from google 2 step verification
                var smtpServer = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new NetworkCredential(from, password),
                    Port = 587,
                    EnableSsl = true,
                };
                try
                {
                    smtpServer.Send(message);
                    MessageBox.Show("Message sent successfully!");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
