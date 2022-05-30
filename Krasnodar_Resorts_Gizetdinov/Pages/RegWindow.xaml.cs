using Krasnodar_Resorts_Gizetdinov.Classes;
using Microsoft.Win32;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {

        public static MongoClient client = new MongoClient();

        OpenFileDialog ofdImage = new OpenFileDialog();
        public RegWindow()
        {
            InitializeComponent();
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

        private void btnImageDel_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.Freeze();
            playim.Source = image;
        }

        private async void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if(Email.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Введите ваши данные!");
            }
            else
            {
                Users us = new Users(Convert.ToString(UserName.Text),
                                     Convert.ToString(Email.Text),
                                     Convert.ToString(Password.Text),
                                     Convert.ToString(Phone.Text),
                                     Convert.ToString("2"),
                                     File.ReadAllBytes(ofdImage.FileName));
                us.Add(us);
                MessageBox.Show("Занесено в базу!");
                AuthWindow auth = new AuthWindow();
                this.Close();
                auth.Show();
            }
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            this.Close();
            auth.Show();

        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-Я а-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Password_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Email.Text == AuthWindow.usclick._email)
            {
                EmailMessageTB.Text = "Не занято!";
                EmailMessageTB.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                EmailMessageTB.Text = "Такая почта существует!";
                EmailMessageTB.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
