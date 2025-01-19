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
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml.Linq;

namespace project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void signup_back_to_home_Click(object sender, RoutedEventArgs e)
        {

            string eb = email_box.Text;
            string ub = username_box.Text;
            string pb = pass_box.Text;


            string mycon = "server=127.0.0.1;user id=root;database=project";
            string query = "insert into sign_up_info values ('"+eb+"','"+ub+"','"+pb+"')";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader;
            con.Open();
            reader = com.ExecuteReader();
            con.Close();

            MainWindow mw = new MainWindow();  
            mw.Show();
            this.Close();
        }

        private void login_back_to_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
