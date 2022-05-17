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
        public static IMongoDatabase database = client.GetDatabase("Krasnodar_resorts");
        public IMongoCollection<Users> col = database.GetCollection<Users>("Users");
        public static Users users = new Users();
        public AuthWindow()
        {
            InitializeComponent();
        }

        public bool Auth()
        {

            return true;
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
