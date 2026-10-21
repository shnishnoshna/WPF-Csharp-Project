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
    /// Логика взаимодействия для AdministratorRoomHotel.xaml
    /// </summary>
    public partial class AdministratorRoomHotel : Page
    {
        public AdministratorRoomHotel()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RoomAdminDataGrid.ItemsSource = ConnectClass.db.Room.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room ROOM = new Room();
            if (Int32.TryParse(RoomNumber.Text, out int numVal))
            {
               
            ROOM.Number = numVal;
            }
            else
            {
               MessageBox.Show("Номер номера не номер");
            }
            if (Int32.TryParse(TextNumber.Text, out int numRoom))
            {

            ROOM.NumberOfRooms = numRoom;
               
            }
            else
            {
                MessageBox.Show("Количество комнат не количество комнат");
            }
            if (Int32.TryParse(Money.Text, out int Moneyy))
            {

                ROOM.CostM = Moneyy;

            }
            else
            {
                MessageBox.Show("Деньги");
            }
            ROOM.NumberOfHoursWorked = 0;
            ROOM.Status = 0;

            //var CorrentUser = ComboBox.SelectedItem as RoleUs;
            //ROOM.RoleID = CorrentUser.ID;

            ConnectClass.db.Room.Add(ROOM);
            ConnectClass.db.SaveChanges();
            RoomAdminDataGrid.ItemsSource = ConnectClass.db.Room.ToList();
            MessageBox.Show("Номер был добавлен)", "Сообщаем:");
        }

        private void Del_Button(object sender, RoutedEventArgs e)
        {
            var CurrentUser = RoomAdminDataGrid.SelectedItem as Room;
            if (MessageBox.Show("Удалим?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ConnectClass.db.Room.Remove(CurrentUser);
                ConnectClass.db.SaveChanges();
                RoomAdminDataGrid.ItemsSource = ConnectClass.db.Room.ToList();
                MessageBox.Show("Готово!)");
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(TextSearch.Text, out int serch))
            {

                RoomAdminDataGrid.ItemsSource = ConnectClass.db.Room.Where(se => se.Number == serch || se.Status == serch).ToList();

            }
            else 
            {
                RoomAdminDataGrid.ItemsSource = ConnectClass.db.Room.ToList();
            }
        }
    }
}
