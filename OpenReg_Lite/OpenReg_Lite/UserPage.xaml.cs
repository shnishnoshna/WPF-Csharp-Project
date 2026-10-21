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
using System.Windows.Media.TextFormatting;
using System.Data.Entity;

namespace OpenReg_Lite
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                var rooms = ConnectClass.db.Room.ToList();
                if (rooms == null || rooms.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения.", "Внимание!");
                    return;
                }
                var filteredRooms = rooms.Where(u => u.Status == 0).ToList();
                UserDataGrid.ItemsSource = filteredRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserDataGrid.SelectedItem is Room currentRoom)
                {
                    var CurrentUser = currentRoom;
                    CurrentUser.Status = 1;
                    TextNum.Text = CurrentUser.Number.ToString();

                    if (!string.IsNullOrWhiteSpace(Nameee.Text))
                    {
                        var user = ConnectClass.db.User.FirstOrDefault(u => u.Login == Nameee.Text);

                        if (user != null)
                        {
                            if (ConnectClass.db.Room.Any(r => r.ID == CurrentUser.ID)) // ПРОВЕРКА ID комнаты
                            {
                                user.RoomLife = CurrentUser.ID;  // Используем ID комнаты
                            }
                            else
                            {
                                MessageBox.Show("Комната с таким ID не найдена в базе данных.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином не найден.");
                            return;
                        }
                        ConnectClass.db.SaveChanges();
                        LoadRooms();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите логин пользователя.");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите комнату из таблицы.");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Ошибка при работе приложения: {ex.Message}";
                Exception innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    errorMessage += $"\nВнутреннее исключение: {innerEx.Message}";
                    innerEx = innerEx.InnerException;
                }
                MessageBox.Show(errorMessage, "Ошибка!");
            }
        }
    }
}

