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
using OpenReg_Lite.ModelBD;

namespace OpenReg_Lite.Views
{
    /// <summary>
    /// Логика взаимодействия для DataBaseP.xaml
    /// </summary>
    public partial class DataBaseP : Page
    {
        public DataBaseP()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserDataGrid.ItemsSource = ConnectClass.db.User.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Del_Button(object sender, RoutedEventArgs e)
        {
            var CurrentUser = UserDataGrid.SelectedItem as User;
            if(MessageBox.Show("Удалим?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) 
            {
                ConnectClass.db.User.Remove(CurrentUser);
                ConnectClass.db.SaveChanges();
                UserDataGrid.ItemsSource = ConnectClass.db.User.ToList();
                MessageBox.Show("Готово!)");
            }
        }
    }
}
