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
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        string randomCode  = "5005";
        // string nwu = "jewel5zubaer.16@gmail.com";//
        public static string to = "zubaer5jewel.16@gmail.com";  //
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn a = new LogIn();
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            msg.Text = email.Text = verifyCode.Text =  "" ;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("jewel5zubaer.16@gmail.com");
                Msg.To.Add(to);
                Msg.Subject = "One Time Password";
                Msg.Body = "Your One Time Password is: " ;
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("jewel5zubaer.16@gmail.com", "jewel.16@");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                MessageBox.Show("Your OTP sent Successfully...");
                //txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (randomCode == (verifyCode.Text).ToString())
            {
                //to = email.Text;
                string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(connectionstring);
                sqlcon.Open();
                string commandstring = "select * from user";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                SqlDataReader read = sqlcmd.ExecuteReader();
                msg.Text = "";


                while (read.Read())
                {

                    msg.Text += "\nUser Name:\t" + read[1].ToString();
                    msg.Text += "\nPassword:\t" + read[2].ToString();

                }
            }
            else
            {
                MessageBox.Show("Wrong Code!!!\nSorry, Try Again!!!");
            }
        }
    }








    
}
