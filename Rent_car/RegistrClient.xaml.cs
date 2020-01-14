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

namespace Rent_car
{
    /// <summary>
    /// Логика взаимодействия для RegistrClient.xaml
    /// </summary>
    public partial class RegistrClient : Window
    {
        public RegistrClient()
        {
            InitializeComponent();
        }

        private void aut_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && SecondName.Text != "" && MiddlName.Text != "" && Phone.Text != "" && Login.Text != "" && Password.Text != "")
            { 
                rentcarEntities db = new rentcarEntities();
            Users save = new Users // Класс пользователя
            {
                Name = Name.Text,
                SecondName = SecondName.Text,
                MiddlName = MiddlName.Text,
                PhoneNumber = Phone.Text,
                Login = Login.Text,
                Password = Password.Text,
                Role = "Client"
            };
            db.Users.Add(save); // добавление класса пользователя
            db.SaveChanges();   // Сохранение класса пользователя
            MessageBox.Show("Клиент добавлен");
            MainWindow reg = new MainWindow();
            this.Hide();
            reg.Show();
        }
           else
            {
                MessageBox.Show("Вы заполнили не все поля");
            }
        }
    }
}
