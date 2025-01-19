using MySql.Data.MySqlClient;
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

namespace project
{
    /// <summary>
    /// Interaction logic for edit.xaml
    /// </summary>
    public partial class edit : Window
    {
        public edit()
        {
            InitializeComponent();
        }

        private void name_box_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            string mycon = "server=127.0.0.1;user id=root;database=project";

            // Get updated values from UI
            string id = id_box.Text;
            string name = name_box.Text;
            string address = Address_box.Text;
            string phone = number_box.Text;
            string email = mail_box.Text;
            string age = age_block.Text;
            string gender = g;
            string country = Country_box.Text;

            // SQL UPDATE query
            string query = @"UPDATE info
                             SET Name = @Name, Address = @Address, Phone = @Phone, Email = @Email, 
                                 Age = @Age, Gender = @Gender, Country = @Country
                             WHERE ID = @ID";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(mycon))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(age) ? DBNull.Value : Convert.ToInt32(age));
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Country", country);

                        // Execute query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
