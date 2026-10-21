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
    /// Логика взаимодействия для RegisrPage.xaml
    /// </summary>
    public partial class RegisrPage : Page
    {
        public RegisrPage()
        {
            InitializeComponent();
            ComboBox.ItemsSource = ConnectClass.db.RoleUs.ToList();
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


        private void TR_TextChanged(object sender, TextChangedEventArgs e)
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
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var currentUser = ConnectClass.db.User.FirstOrDefault(u => u.Login == TR.Text);
            if(currentUser != null) 
            {
                MessageBox.Show("Пользователь с таким логином уже существует!)","Сообщаем");
                return;
            }
            User people = new User();
            people.Login = TR.Text;
            people.Password = TRP.Text;

            var CorrentUser = ComboBox.SelectedItem as RoleUs;
            people.RoleID = CorrentUser.ID;

            ConnectClass.db.User.Add(people);
            ConnectClass.db.SaveChanges();
            MessageBox.Show("Данный пользователь был зарегистрирован!)","Сообщаем:");
            NavigationService.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
