using Krasnodar_Resorts_Gizetdinov.Classes;
using Microsoft.Win32;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Krasnodar_Resorts_Gizetdinov.Pages
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        OpenFileDialog ofdImage = new OpenFileDialog();
        public static MongoClient client = new MongoClient();

        public AdminPage()
        {
            InitializeComponent();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Users>("Users");
            var a = abase.GetCollection<Resorts>("Resort");
            Card2.Text = Convert.ToString(b.AsQueryable().Count());
            Card.Text = Convert.ToString(a.AsQueryable().Count());

        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text == "" || PriceTB.Text == "")
            {
                MessageBox.Show("Введите ваши данные!");
            }
            else
            {
                Resorts resorts = new Resorts(Convert.ToString(NameTB.Text),
                                     Convert.ToString(PriceTB.Text),
                                     Convert.ToString(DescriptionTB.Text),
                                     File.ReadAllBytes(ofdImage.FileName));
                resorts.Add(resorts);
                MessageBox.Show("Занесено в базу!");
                MainPage main = new MainPage();
                var abase = client.GetDatabase("Krasnodar_resorts");
                var b = abase.GetCollection<Users>("Users");
                var a = abase.GetCollection<Resorts>("Resort");
                main.list_Service.ItemsSource = b.AsQueryable().ToList();
            }
        }

        private void btn_ImageDel_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.Freeze();
            playim.Source = image;
        }

        private void btn_Image_Click(object sender, RoutedEventArgs e)
        {
            ofdImage.Filter = "Image files|*.bmp;*.jpg;*.png|All files|*.*";
            ofdImage.FilterIndex = 1;
            if (ofdImage.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdImage.FileName);
                image.EndInit();
                playim.Source = image;
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            NameTB.Clear();
            PriceTB.Clear();
            DescriptionTB.Clear();
            BitmapImage image = new BitmapImage();
            image.Freeze();
            playim.Source = image;
        }

        private void PriceTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertResortPage());
        }

        
    }
}
