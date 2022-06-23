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
    /// Логика взаимодействия для SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        public static MongoClient client = new MongoClient();
        public SalePage()
        {
            InitializeComponent();
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<Product>("Product");
            list_Service.ItemsSource = b.AsQueryable().ToList();
        }

        private void btn_Buy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SalePaymentPage());
        }

        
    }
}
