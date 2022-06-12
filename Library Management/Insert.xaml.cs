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
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        public Insert()
        {
            InitializeComponent();
        }
        public string ID, WName, BName,  Dment;

        private void insertBack(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void insertReset(object sender, RoutedEventArgs e)
        {
            StudentID.Text = WriterName.Text = BookName.Text  = Department.Text = "";
        }

        private void insertSave(object sender, RoutedEventArgs e)
        {

           

            
            if (StudentID.Text == "" || WriterName.Text == "" || BookName.Text == "" || Department.Text == "")
            {
                MessageBox.Show("Insert Valid Data !");
                return;
            }


            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into bookData(StudentID,BookName,WriterName,Department) values(@a,@b,@c,@d)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = StudentID.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = BookName.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = WriterName.Text;
            
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = Department.Text;
            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Save Successfull");
            sqlcon.Close();
        }

        private void StudentID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
