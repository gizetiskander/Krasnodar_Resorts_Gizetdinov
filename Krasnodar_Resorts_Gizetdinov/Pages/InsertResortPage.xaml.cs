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
    /// Interaction logic for InsertResortPage.xaml
    /// </summary>
    public partial class InsertResortPage : Page
    {
        public static MongoClient client = new MongoClient();
        public InsertResortPage()
        {
            InitializeComponent();
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Oil>("Resort");
            list_Service.ItemsSource = b.AsQueryable().ToList();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var abase = client.GetDatabase("Krasnodar_resorts");
            var b = abase.GetCollection<Oil>("Resort");
            var q = list_Service.SelectedItem = b; 
            if (q == null)
            {
                MessageBox.Show("Ничего не выбрано!");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удалить?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var select = (Oil)list_Service.SelectedItem;
                    b.FindOneAndDelete(p => p.Id == select.Id);
                    list_Service.ItemsSource = b.AsQueryable().ToList();
                }
                catch
                {
                    MessageBox.Show("Удалите соединения связанные с этим данным");
                }

            }
        }
    }
}
