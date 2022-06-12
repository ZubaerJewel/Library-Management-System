using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textUser.Text == "" || textPass.Text == "")
            {
                MessageBox.Show("Please enter username and password to login");
                return;
            }

            string connectionstring = @"Data Source=.;Initial Catalog=Library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "select username from users where username= '" + textUser.Text + "'" + " and  password ='" + textPass.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows > 0)
                MessageBox.Show("Incorrect username or password.\nPlease enter username and password correctly.");
            else
            {
                MainWindow a = new MainWindow();
                a.Show();
                this.Close();
            }

        }
    }
}
