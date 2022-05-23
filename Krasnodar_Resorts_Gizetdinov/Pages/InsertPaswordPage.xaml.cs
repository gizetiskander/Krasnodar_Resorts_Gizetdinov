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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
    /// <summary>
    /// Interaction logic for InsertPaswordPage.xaml
    /// </summary>
    public partial class InsertPaswordPage : Page
    {
        public static MongoClient client = new MongoClient();
        

    
        public InsertPaswordPage()
        {
            InitializeComponent();
        }

   
        private void btn_InsertPassword_Click(object sender, RoutedEventArgs e)
        {
            if (OldPasswordTB.Text == "" || NewPasswordTB.Text == "" || ConfirmPasswordTB.Text == "")
            {
                MessageBox.Show("Введите ваши данные!");
            }
            else
            {
                var abase = client.GetDatabase("Krasnodar_resorts");
                var b = abase.GetCollection<Users>("Users");
                var filter = Builders<Users>.Filter.Eq("Id", AuthWindow.usclick.Id);
                var update = Builders<Users>.Update.Set("_password", NewPasswordTB.Text);
                var result = b.UpdateOne(filter, update);
                MessageBox.Show("Пароль изменен!");
                NavigationService.GoBack();
            }            
            

        }

        private void OldPasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OldPasswordTB.Text == AuthWindow.usclick._password)
            {
                OldPasswordMessageTB.Text = "Пароль верный!";
                OldPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                OldPasswordMessageTB.Text = "Пароль неверный!";
                OldPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void ConfirmPasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ConfirmPasswordTB.Text == NewPasswordTB.Text)
            {
                ConfirmPasswordMessageTB.Text = "Пароль совпал!";
                btn_InsertPassword.IsEnabled = true;
                ConfirmPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                ConfirmPasswordMessageTB.Text = "Пароль не совпадает!";
                btn_InsertPassword.IsEnabled = false;
                ConfirmPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void NewPasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ConfirmPasswordTB.Text == NewPasswordTB.Text)
            {
                ConfirmPasswordMessageTB.Text = "Пароль совпал!";
                btn_InsertPassword.IsEnabled = true;
                ConfirmPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                ConfirmPasswordMessageTB.Text = "Пароль не совпадает!";
                btn_InsertPassword.IsEnabled = false;
                ConfirmPasswordMessageTB.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
