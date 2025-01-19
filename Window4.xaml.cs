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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
      
        public Window4()
        {
            InitializeComponent();
            LoadData();
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5();
            w5.Show();
        }

        

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5();
            w5.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string i = d.Text;
            string mycon = "server=127.0.0.1;user id=root;database=project";
            string query = "delete from info where ID ='" + i + "'";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand comm = new MySqlCommand(query, con);
            MySqlDataReader reader;
            con.Open();
            reader = comm.ExecuteReader();
            MessageBox.Show(reader.ToString());
            con.Close();
            MessageBox.Show("success");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            edit ed = new edit();
            ed.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }
        private void LoadData()
        {
            // Connection string for your MySQL database
            string mycon = "server=127.0.0.1;user id=root;database=project";

            // Query to fetch all data from your table
            string query = "SELECT * FROM info";

            using (MySqlConnection connection = new MySqlConnection(mycon))
            {
                try
                {
                    connection.Open(); // Open connection
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection); // Create data adapter
                    DataTable dataTable = new DataTable(); // Create a data table
                    dataAdapter.Fill(dataTable); // Fill the data table with query results
                    DataGridView.ItemsSource = dataTable.DefaultView; // Bind the DataGrid to the DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Display error message
                }
            }
        }

        
    }
}
