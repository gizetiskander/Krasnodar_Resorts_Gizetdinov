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
using Krasnodar_Resorts_Gizetdinov.Classes;
using MongoDB.Driver;

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {

        public static MongoClient client = new MongoClient();

        public PaymentPage()
        {
            InitializeComponent();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Resorts>("Resort");
            TarifCB.ItemsSource = b.AsQueryable();

        }

        private void TarifCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Resorts>("Resort");
            PriceTB.Text = b.AsQueryable().Where(x => x._price == TarifCB.Items.ToString()).FirstOrDefault();
        }

        private void PaymentCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Pay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
