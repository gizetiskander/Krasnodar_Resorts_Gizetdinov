using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Krasnodar_Resorts_Gizetdinov.Classes;
using MongoDB.Driver;

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
   
    /// <summary>
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {
        public static MongoClient client = new MongoClient();
        public static Users us;
        public static Payment pay;
        public PersonalPage(Users user)
        {
            InitializeComponent();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Users>("Users");
            var a = abase.GetCollection<Payment>("Payment");
            AuthWindow.usclick = user;
            MemoryStream byteStream = new MemoryStream(user._image);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            image_Personal.Source = image;
            UserNameTB.Text = AuthWindow.usclick._name;
            TelephoneTB.Text = AuthWindow.usclick._phone;
            EmailTB.Text = AuthWindow.usclick._email;

            
        }

        private void btn_Password_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertPaswordPage());
        }
    }
}
