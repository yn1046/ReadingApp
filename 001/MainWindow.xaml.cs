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
using System.Data.SqlClient;

namespace _001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var password = Password.Password;
                if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(password)) throw new Exception("Введите логин и пароль");

                var user = new EF.User();
                
                using (var db = new EF.Context())
                {
                    if (!db.Users.Any(u=> u.Login.Equals(Login.Text) && u.Password.Equals(password))) throw new Exception("Такого пользователя не существует");
                    else user = db.Users.FirstOrDefault(u => u.Login.Equals(Login.Text) && u.Password.Equals(password));
                }

                Shelf shelf = new Shelf(user);
                shelf.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
                return;
            }
        }

    }
}
