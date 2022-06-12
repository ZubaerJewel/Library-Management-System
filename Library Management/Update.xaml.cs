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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {

        class ComboBoxItem
        {
            public string Name;
            public long Value;
            public ComboBoxItem(string Name, long Value)
            {
                this.Name = Name;
                this.Value = Value;
            }

            // override ToString() function
            public override string ToString()
            {
                return this.Name;
            }
        }

        public Update()
        {
            InitializeComponent();
        }

        private void updateShow(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Insert Valid Data !");
                return;
            }
           
            //comboBoxWriter.Items.Clear();
         
            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            try
            {
                sqlcon.Open();
                string commandstring = "select * from bookData where WriterName ='" + textBox1.Text + "' AND BookName ='" + BookName.Text + "';";
                // select * from bookData where WriterName ='' AND BookName ='';
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
                Console.WriteLine(ex.Message);
            }
 
        }


        private void updateBack(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void updateReset(object sender, RoutedEventArgs e)
        {
           comboBoxWriter.Text = textBox1.Text = BookName.Text = StudentID.Text = Department.Text = "";
        }

        private void saveUpdate(object sender, RoutedEventArgs e)
        {
            if (StudentID.Text == "" || BookName.Text == "" || Department.Text == "")
            {
                MessageBox.Show("Insert Valid Data !");
                return;
            }
            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "update bookData set BookName=@a,StudentID=@b,Department=@c  where id ='" + textBoxID.Text + "';";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = BookName.Text;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = StudentID.Text;
            
            sqlcmd.Parameters.Add("@c", SqlDbType.VarChar).Value = Department.Text;
           

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows == 1)
                MessageBox.Show("Information Has Updated.");


        }

        private void BookName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    

        private void selected(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row;
            if (msg.SelectedItems[0].GetType().ToString() == "System.Data.DataRowView")
            {
                row = (DataRowView)msg.SelectedItems[0];
                BookName.Text = row["BookName"].ToString();
                StudentID.Text = row["StudentID"].ToString();
                textBox1.Text = row["WriterName"].ToString();
                Department.Text = row["Department"].ToString();
                textBoxID.Text= row["id"].ToString();
            }
        }
    }
}
