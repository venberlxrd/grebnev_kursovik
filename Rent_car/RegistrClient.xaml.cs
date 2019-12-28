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
            rentcarEntities db = new rentcarEntities();
            Users save = new Users
            {
                  Name = Name.Text,
                  SecondName = SecondName.Text,
                  MiddlName = MiddlName.Text,
                  PhoneNumber = Phone.Text,
                  Login = Login.Text,
                  Password = Password.Text,
                  Role  ="Client"
            };
            db.Users.Add(save);
            db.SaveChanges();
            MessageBox.Show("Клиент добавлен");
            MainWindow reg = new MainWindow();
            this.Hide();
            reg.Show();
        }
    }
}
