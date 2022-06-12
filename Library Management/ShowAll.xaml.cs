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
    /// Interaction logic for ShowAll.xaml
    /// </summary>
    public partial class ShowAll : Window
    {
        public ShowAll()
        {
            InitializeComponent();
            showAllRecords();
        }

        private void showAllRecords()
        {
            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            try
            {
                sqlcon.Open();
                string commandstring = "select id,StudentID,BookName,WriterName,Department from bookData";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                //SqlDataReader read = sqlcmd.ExecuteReader();
                sqlcmd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable("bookData");
                dataAdp.Fill(dt);
                textBlock.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);




                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

    

        private void ShowBack(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
