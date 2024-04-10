using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace dostavki
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void admin_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [users]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("users");
                sda.Fill(dt);
                admin.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [users] ([role], [login], [password], [fio]) VALUES ('3', '{login.Text}', '{password.Text}', '7')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (admin.SelectedItem != null)
            {
                DataRowView row = (DataRowView)admin.SelectedItem;
                int id = (int)row["id"];
                string deleteQuery = "DELETE FROM [users] WHERE ID = @id";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [users]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("users");
                sda.Fill(dt);
                admin.ItemsSource = dt.DefaultView;
            }
        }

        private void zakaz_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazs]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazs");
                sda.Fill(dt);
                zakaz.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [zakazs] ([zakaz], [adess], [count], [status], [fio]) VALUES ( '{zakazs.Text}', '{adress.Text}', '{count.Text}', '1', '7')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click_2(object sender, RoutedEventArgs e)
        {
            if (admin.SelectedItem != null)
            {
                DataRowView row = (DataRowView)zakaz.SelectedItem;
                int id = (int)row["id"];
                string deleteQuery = "DELETE FROM [zakazs] WHERE ID = @id";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


        }

        private void refresh_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazs]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazs");
                sda.Fill(dt);
                zakaz.ItemsSource = dt.DefaultView;
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                string newText = "2";
                string query = "UPDATE [zakazs] SET [status] = @NewText ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
