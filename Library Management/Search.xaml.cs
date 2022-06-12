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
using System.Data;
using System.Data.SqlClient;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }
       
        private void searchSearch(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            
            //msg.Text = "Result : ";
            try
            {
                sqlcon.Open();
                string commandstring = "select * from bookData where WriterName = '" + textBox.Text + "';";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
               
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable("bookData");
                dataAdp.Fill(dt);
                msg.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            msg.ItemsSource = textBox.Text = "";
        }
    }
}
