using Krasnodar_Resorts_Gizetdinov.Classes;
using MongoDB.Driver;
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

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        MongoClient client = new MongoClient();

        Users users = new Users();
        public AuthWindow()
        {
            InitializeComponent();
        }

        public bool Auth(string nickname, string password)
        {
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Users>("Users");
            var listPerson = b.Find(Resorts => Resorts._name == nickname && Resorts._password == password && Resorts._role == "1" || Resorts._role == "2").ToList().FirstOrDefault();
            if (listPerson._name == "Admin" && listPerson._password == "123" && listPerson._role == "1")
            {
                MessageBox.Show($"Добро пожаловать Администратор");
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password) || listPerson == null)
            {
                MessageBox.Show("Введите логин и пароль или введены неправильные данные");
                return false;
            }
            else if (listPerson != null)
            {
                MessageBox.Show($"Добро пожаловать {listPerson._name}");
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }

            return true;
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login.Text, Password.Password);
        }
    }
}
