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
        Users us;

    
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
                MessageBox.Show("Пароль изменен!");
            }
            

        }


        private void OldPasswordTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OldPasswordTB.Text == AuthWindow.usclick._password)
            {
                MessageBox.Show("Пароль верный!");
            }
            else
            {
                MessageBox.Show("Пароль не верный!");
            }
        }
    }
}
