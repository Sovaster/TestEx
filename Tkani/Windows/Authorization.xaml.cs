using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Tkani.Fabrics_Data_SetTableAdapters;

namespace Tkani
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        Fabrics_Data_Set fabrics_Data_Set = new Fabrics_Data_Set();
        UserTableAdapter userTableAdapter = new UserTableAdapter();

        private String connectionString;
        private SqlConnection connection;
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        public Authorization()
        {
            InitializeComponent();

            userTableAdapter.Fill(fabrics_Data_Set.User);

            stringBuilder.ConnectionString = Properties.Settings.Default.FabricsConnectionString;
            connectionString = stringBuilder.ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void Authorization_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (Login_TB.Text != "" && Password_PB.Password != "")
            {
                try
                {
                    command.CommandText = "Select * from [User] where User_Login = '" + Login_TB.Text + "' AND User_Password = '" + Password_PB.Password+"'";
                    command.Connection = connection;
                    connection.Open();
                    reader = command.ExecuteReader();
                    int count = 0;
                    string user_role = "";
                    string user_FIO = "";
                    while (reader.Read())
                    {
                        count++;
                        user_role = Convert.ToString(reader["Role_Name"]);
                        user_FIO = Convert.ToString(reader["User_Surname"]) +" "+ Convert.ToString(reader["User_Name"]) +" "+ Convert.ToString(reader["User_Middle_Name"]);
                    }
                    if (count == 1)
                    {
                        connection.Close();
                        switch(user_role)
                        {
                            case "Администратор":
                                Windows.Product_Administartor_Window window_for_admin = new Windows.Product_Administartor_Window(/*user_FIO*/);
                                window_for_admin.Show();
                                this.Close();
                                break;
                            case "Менеджер":
                                Window window_for_menedjer = new Window();
                                window_for_menedjer.Show();
                                this.Close();
                                break;
                            case "Клиент":
                                Window window_for_klient = new Window();
                                window_for_klient.Show();
                                this.Close();
                                break;
                        }
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Неверный логин или пароль!\n Повторите попытку входа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    connection.Close();
                    MessageBox.Show("Ошибка связи с сервером!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Guest_BTN_Click(object sender, RoutedEventArgs e)
        {
            string user_FIO = "Гость";
            Window window_for_klient = new Window();
            window_for_klient.Show();
            this.Close();
        }

        private void Login_Password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex login_regex = new Regex("[^а-яА-ЯёЁ]");
            e.Handled = !login_regex.IsMatch(e.Text);
        }
    }
}
