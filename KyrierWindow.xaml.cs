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
    /// Логика взаимодействия для KyrierWindow.xaml
    /// </summary>
    public partial class KyrierWindow : Window
    {
        public KyrierWindow()
        {
            InitializeComponent();
        }

        private void kyrier_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazs]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazs");
                sda.Fill(dt);
                kyrier.ItemsSource = dt.DefaultView;
            }
        }

        private void done_click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                DataRowView row = (DataRowView)kyrier.SelectedItem;
                string newText = "3";
                int id = (int)row["id"];
                string query = "UPDATE [zakazs] SET [status] = @NewText WHERE ID = @id ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void prepare_click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                DataRowView row = (DataRowView)kyrier.SelectedItem;
                string newText = "2";
                int id = (int)row["id"];
                string query = "UPDATE [zakazs] SET [status] = @NewText WHERE ID = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void refreh_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=kymys; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazs]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazs");
                sda.Fill(dt);
                kyrier.ItemsSource = dt.DefaultView;
            }
        }
    }
}
