using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace dostavki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Вход_Click(object sender, RoutedEventArgs e)
        {
            {
                var windows = new Dictionary<string, Window>
{
{ "admin", new AdminWindow() },
{ "kyrier", new KyrierWindow() },
{ "user", new UserWindow() } };

                using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;;Integrated Security=True"))
                {
                    using (var connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;;Integrated Security=True"))
                    {
                        con.Open();
                        var cmd = new SqlCommand($"SELECT roles.role FROM [roles] left join users on users.role = roles.id WHERE [login]='{login.Text}' AND [password]='{password.Password}'", con);
                        var userRole = cmd.ExecuteScalar() as String;

                        if (windows.TryGetValue(userRole, out var window)) { window.Show(); }
                        else { MessageBox.Show("Неверные данные"); }
                    }
                }
            }
        }




        private void Регистрация_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=kymys;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [users] ([role], [login], [password], [fio]) VALUES ('3', '{login.Text}', '{password.Password}', '7')", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
