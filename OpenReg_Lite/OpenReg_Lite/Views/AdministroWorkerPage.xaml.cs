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
    /// Логика взаимодействия для AdministroWorkerPage.xaml
    /// </summary>
    public partial class AdministroWorkerPage : Page
    {
        private List<User> filteredUsers; // Храним отфильтрованных пользователи
        private List<User> allUsers; // Храним всех пользователи
        public AdministroWorkerPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                allUsers = ConnectClass.db.User.ToList(); // Получаем ВСЕХ пользователей
                if (allUsers == null || allUsers.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения.", "Внимание!");
                    return;
                }

                filteredUsers = allUsers.Where(u => u.RoleID == 3).ToList(); // Фильтруем по роли 3
                if (filteredUsers == null || filteredUsers.Count == 0)
                {
                    MessageBox.Show("Нет пользователей с заданной ролью.", "Внимание!");
                    return;
                }

                UserAdminDataGrid.ItemsSource = filteredUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка!");
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (filteredUsers == null)
                {
                    MessageBox.Show("Ошибка: filteredUsers не инициализирован.", "Ошибка!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(TextSearch.Text))
                {
                    UserAdminDataGrid.ItemsSource = filteredUsers;  // Показать всех, если поле пустое
                    return;
                }

                var searchResults = filteredUsers.Where(user => user.Login.ToLower().Contains(TextSearch.Text.ToLower())).ToList();

                if (!searchResults.Any())
                {
                    MessageBox.Show($"Пользователи с таким логином не найдены.", "Внимание!");
                }
                UserAdminDataGrid.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка!");
            }
        }
    }
}
