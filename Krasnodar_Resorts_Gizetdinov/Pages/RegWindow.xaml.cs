using Microsoft.Win32;
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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void btn_Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdImage = new OpenFileDialog();
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

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            this.Close();
            auth.Show();

        }
    }
}
