using Krasnodar_Resorts_Gizetdinov.Classes;
using MongoDB.Bson;
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

        public static MongoClient client = new MongoClient();
  
        public static Users users = new Users();
        public static Users usclick;
        public AuthWindow()
        {
            InitializeComponent();
        }

        public bool Auth(string nickname, string password)
        {
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Users>("Users");
            var listPerson = b.Find(Resorts => Resorts._email == nickname && Resorts._password == password).ToList().FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password) || listPerson == null)
                {
                    MessageBox.Show("Введите логин и пароль или введены неправильные данные");
                    return false;
                }
                else if (listPerson._email == nickname && listPerson._password == password && listPerson._role == "1")
                {
                    MessageBox.Show($"Добро пожаловать администратор: {listPerson._name} ");
                    usclick = listPerson;
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                    mainWindow.btn_Admin.Visibility = Visibility.Visible;
                }

                else if (listPerson._email == nickname && listPerson._password == password && listPerson._role == "2")
                {
                    MessageBox.Show($"Добро пожаловать пользователь:  {listPerson._name}");
                    usclick = listPerson;
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                    mainWindow.btn_Admin.Visibility = Visibility.Hidden;
                }
            }
            catch
            {
                MessageBox.Show("Введите логин и пароль или введены неправильные данные");
            }

            return true;
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login.Text, Password.Password); 

        }
    }
}
