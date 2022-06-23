using System;
using System.Collections.Generic;
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
using Krasnodar_Resorts_Gizetdinov.Classes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {

        public static MongoClient client = new MongoClient();
        public static Oil resorts;
        public static Payment pay;

        public PaymentPage()
        {
            InitializeComponent();
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<Oil>("Oil");
            var a = abase.GetCollection<PaymentType>("PaymentType");
            PaymentCB.ItemsSource = a.AsQueryable().ToList();
            TarifCB.ItemsSource = b.AsQueryable().ToList();

        }

        private void TarifCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<Oil>("Oil");
            var filter = Builders<Oil>.Filter.Eq("_price", "43,15");
            var filter1 = Builders<Oil>.Filter.Eq("_price", "47,60");
            var filter2 = Builders<Oil>.Filter.Eq("_price", "61,95");
            var price1 = b.Find(filter).ToList();
            var price2 = b.Find(filter1).ToList();
            var price3 = b.Find(filter2).ToList();
            foreach(var p in price1)
            {
                if (TarifCB.SelectedIndex == 0)
                {
                    PriceTB.Text = p._price;
                }
            }
            foreach(var p in price2)
            {
                if (TarifCB.SelectedIndex == 1)
                {
                    PriceTB.Text = p._price;
                }
            }
            foreach (var p in price3)
            {
                if (TarifCB.SelectedIndex == 2)
                {
                    PriceTB.Text = p._price;
                }
            }
        }
    
       

        private void btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTB.Text == "" || Card.Text == "" || PriceTB.Text == "")
            {
                MessageBox.Show("Введите ваши данные!");
            }
            else
            {
                var servName = ((Oil)TarifCB.SelectedItem)._name;
                var payName = ((PaymentType)PaymentCB.SelectedItem)._name;
                Payment payment = new Payment(Convert.ToString(UserNameTB.Text),
                                          Convert.ToString(servName),
                                          Convert.ToString(payName),
                                          Convert.ToString(Card.Text),
                                          Convert.ToString(PriceTB.Text),
                                          (true), DateTime.Now);
                var abase = client.GetDatabase("Eco_Oil");
                var b = abase.GetCollection<Payment>("Payment");
                payment.Add(payment);
                MessageBox.Show("Покупка совершена!");
                NavigationService.Navigate(new OrderPage(AuthWindow.usclick));
            }
           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Card_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserNameTB.Text == AuthWindow.usclick._name)
            {
                ConfirmNameTB.Text = "Имя верное!";
                btn_Pay.IsEnabled = true;
                ConfirmNameTB.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                ConfirmNameTB.Text = "Имя неверное!";
                btn_Pay.IsEnabled = false;
                ConfirmNameTB.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void btn_Calendar_Click(object sender, RoutedEventArgs e)
        {
            DateOfFlyCL.Visibility = Visibility.Visible;
            btn_CloseCalendar.Visibility = Visibility.Visible;

        }

        private void btn_CloseCalendar_Click(object sender, RoutedEventArgs e)
        {
            DateOfFlyCL.Visibility = Visibility.Hidden;
        }

        private void DateOfFlyCL_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DateOfFlyCL.SelectedDate;
            MessageBox.Show(selectedDate.Value.Date.ToLongDateString());
        }

        private void LitrCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var abase = client.GetDatabase("Eco_Oil");
            var b = abase.GetCollection<Oil>("Oil");
            var filter = Builders<Oil>.Filter.Eq("_price", "43,15");
            var filter1 = Builders<Oil>.Filter.Eq("_price", "47,60");
            var filter2 = Builders<Oil>.Filter.Eq("_price", "61,95");
            var price1 = b.Find(filter).ToList();
            var price2 = b.Find(filter1).ToList();
            var price3 = b.Find(filter2).ToList();
            foreach (var p in price1)
            {
                if (LitrCB.SelectedIndex == 0)
                {
                    PriceTB.Text = "431,15";
                }
                if (LitrCB.SelectedIndex == 1)
                {
                    PriceTB.Text = "863";
                }
                if (LitrCB.SelectedIndex == 2)
                {
                    PriceTB.Text = "1294,5";
                }
                if (LitrCB.SelectedIndex == 3)
                {
                    PriceTB.Text = "1726";
                }
                if (LitrCB.SelectedIndex == 4)
                {
                    PriceTB.Text = "2157,5";
                }
            }
            foreach (var p in price2)
            {
                if (LitrCB.SelectedIndex == 0)
                {
                    PriceTB.Text = "476";
                }
                if (LitrCB.SelectedIndex == 1)
                {
                    PriceTB.Text = "952";
                }
                if (LitrCB.SelectedIndex == 2)
                {
                    PriceTB.Text = "1428";
                }
                if (LitrCB.SelectedIndex == 3)
                {
                    PriceTB.Text = "1904";
                }
                if (LitrCB.SelectedIndex == 4)
                {
                    PriceTB.Text = "2380";
                }
            }
            foreach (var p in price3)
            {
                if (LitrCB.SelectedIndex == 0)
                {
                    PriceTB.Text = "619,5";
                }
                if (LitrCB.SelectedIndex == 1)
                {
                    PriceTB.Text = "1239";
                }
                if (LitrCB.SelectedIndex == 2)
                {
                    PriceTB.Text = "1858,5";
                }
                if (LitrCB.SelectedIndex == 3)
                {
                    PriceTB.Text = "2478";
                }
                if (LitrCB.SelectedIndex == 4)
                {
                    PriceTB.Text = "3097,5";
                }
            }
        }
    }
}
