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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert(object sender, RoutedEventArgs e)
        {
            Insert a = new Insert();
            a.Show();
            this.Close();
        }


        private void btndeleteClick(object sender, RoutedEventArgs e)
        {
            Delete a = new Delete();
            a.Show();
            this.Close();
        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            Search a = new Search();
            a.Show();
            this.Close();
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {
            Update a = new Update();
            a.Show();
            this.Close();
        }

        private void ShowClick(object sender, RoutedEventArgs e)
        {
            ShowAll a = new ShowAll();
            a.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
