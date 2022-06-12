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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void deleteDelete(object sender, RoutedEventArgs e)
        {
            if (StudentID.Text == "" || BookName.Text == "" )
            {
                MessageBox.Show("Insert Valid Data !");
                return;
            }
            
            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "delete from bookData where StudentID= '" + StudentID.Text + "'" +" and  BookName ='"+ BookName.Text+"'" ;
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
           
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows > 0)
                MessageBox.Show("Information Has Deleted.");

        }

        private void deleteBack(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
