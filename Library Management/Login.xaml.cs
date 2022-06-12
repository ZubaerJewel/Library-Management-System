using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Net;
using System.Net.Mail;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            //InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textUser.Text == "" || textPass.Password == "")
            {
                MessageBox.Show("Please enter username and password to login");
                return;
            }

            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "SELECT username FROM users WHERE username='" + textUser.Text + "'" + "AND password ='" + textPass.Password + "';";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);

            sqlcon.Open();
            SqlDataReader read = sqlcmd.ExecuteReader();

            if (read.Read())
            {
                MainWindow a = new MainWindow();
                a.Show();
                this.Close();
                sqlcon.Close();
            }
            else
                MessageBox.Show("Incorrect!!!!\n[Please Enter Correctly]");
            sqlcon.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
               
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("jewel5zubaer.16@gmail.com");
                Msg.To.Add("zubaer5jewel.16@gmail.com");
                Msg.Subject = "Username and Password for NWU Library Management Software";
               
                Msg.Body = "Your One Time User Name : NWU  Password : NWUKhulna@";
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("jewel5zubaer.16@gmail.com", "jewel.16@");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                MessageBox.Show("Your UserName and Password Sent Successfully...\n\n Please Check your Email!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
