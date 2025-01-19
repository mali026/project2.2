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

namespace project
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int age = (int)e.NewValue;
            age_block.Text = age.ToString();
        }
        string g;
        private void female_Checked(object sender, RoutedEventArgs e)
        {
            g = "Female";
        }
        private void male_Checked(object sender, RoutedEventArgs e)
        {
            g = "Male";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameb=name_box.Text;
            string ab=Address_box.Text;
            string nb=number_box.Text;
            string mb=mail_box.Text;
            string abl=age_block.Text;
            string c=Country_box.Text;
            string i= id_box.Text;
            string ge = g;

            string mycon = "server=127.0.0.1;user id=root;database=project";
            string query = "insert into info values ('"+i+"','"+nameb+"','"+ab+"','"+nb+ "','"+mb+ "','"+abl+ "','"+ ge +"','"+c+"' )";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader reader;
            con.Open();
            reader = com.ExecuteReader();
            con.Close();
            Window4 w4 = new Window4();
            w4.Show();
            this.Close();
        }

        
    }
}
