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
using OpenReg_Lite.Views;

namespace OpenReg_Lite
{
    /// <summary>
    /// Логика взаимодействия для MainP.xaml
    /// </summary>
    public partial class MainP : Page
    {
        public MainP()
        {
            InitializeComponent();

            
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TR.Text == "")
            {
                TRF.Visibility = Visibility.Visible;
            }
            else
            {
                TRF.Visibility = Visibility.Hidden;
            }
        }
        private void TRP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TRP.Text == "")
            {
                TRFP.Visibility = Visibility.Visible;
            }
            else
            {
                TRFP.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TR.Clear();
            TR.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TRP.Clear();
            TRP.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var currentUser = ConnectClass.db.User.FirstOrDefault(u => u.Login == TR.Text && u.Password == TRP.Text);
            if (currentUser == null) { MessageBox.Show("Нет такого пользователя!", "Сообщаем:"); }
            else
            {
                var CheckRoleUser = ConnectClass.db.RoleUs.FirstOrDefault(r => r.ID == currentUser.RoleID);

                if (currentUser != null)
                {

                    switch (CheckRoleUser.Title)
                    {
                        case "Разработчик":
                            NavigationService.Navigate(new DataBaseP());
                            break;
                        case "Администратор":
                            NavigationService.Navigate(new AdministratoPage());
                            break;
                        case "Пользователь":
                            NavigationService.Navigate(new UserPage());
                            break;
                        case "Работник":
                            NavigationService.Navigate(new AdministratoPage());
                            break;
                        default:
                            MessageBox.Show("Не коректная роль!", "Сообщаем:");
                            break;
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisrPage());
        }
    }
}
