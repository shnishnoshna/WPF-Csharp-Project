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

namespace OpenReg_Lite.Views
{
    /// <summary>
    /// Логика взаимодействия для AdministratoPage.xaml
    /// </summary>
    public partial class AdministratoPage : Page
    {
        public AdministratoPage()
        {
            InitializeComponent();
            FrameReg.Navigate(new AdministratorRoomHotel());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameReg.Navigate(new AdministratorRoomHotel());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameReg.Navigate(new AdministroUserPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameReg.Navigate(new AdministroWorkerPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameReg.Navigate(new AdministroPenPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameReg.Navigate(new AdministroManeyPage());
        }
    }
}
