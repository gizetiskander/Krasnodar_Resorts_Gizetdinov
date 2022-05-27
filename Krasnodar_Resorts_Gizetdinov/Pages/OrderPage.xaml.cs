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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public static MongoClient client = new MongoClient();
        public OrderPage(Users user)
        {
            InitializeComponent();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Payment>("Payment");
            AuthWindow.usclick = user;
            var name = AuthWindow.usclick._name;
            list_Order.ItemsSource = b.AsQueryable().Where(x => x._username == AuthWindow.usclick._name).ToList();

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
