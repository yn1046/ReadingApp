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
using System.Windows.Shapes;

namespace _001
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var password = Password.Password;
                var repPassword = RepeatPassword.Password;

                if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repPassword)) throw new Exception("Заполните все поля");
                if (Login.Text.Length > 50 || password.Length > 50) throw new Exception("Слишком длинный логин/пароль");
                if (!password.Equals(repPassword)) throw new Exception("Пароли должны совпадать");

                using (var db = new EF.Context())
                {
                    if (db.Users.Any(u => u.Login.Equals(Login.Text))) throw new Exception("Пользователь с таким именем уже существует");

                    var user = new EF.User()
                    {
                        Login = Login.Text,
                        Password = password
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                var str = "Пользователь " + Login.Text + " успешно добавлен";
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
                return;
            }
        }
    }
}
