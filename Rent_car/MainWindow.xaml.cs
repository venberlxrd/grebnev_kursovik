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

namespace Rent_car
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aut_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "" && Password.Password != "")
            {
                try
                {

                    rentcarEntities db = new rentcarEntities(); 
                    var rol = db.Users.Where(us => us.Login == Login.Text && us.Password == Password.Password).FirstOrDefault().Role; //
                    var f = db.Users.Where(us => us.Login == Login.Text && us.Password == Password.Password).FirstOrDefault().IdUser;

                    if (rol == "Client")
                    {
                        ClientForn re = new ClientForn();
                        this.Hide();
                        SecurityContext.idClient = f;
                        re.Show();
                        SecurityContext.avtovxod = 1;
                    }
                    else if (rol == "Manager")
                    {
                        ManagerForm re = new ManagerForm();
                        this.Hide();
                        re.Show();
                        SecurityContext.avtovxod = 3;
                    }
                }
                catch
                {
                    MessageBox.Show("Вы ввели неправильно логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все поля");
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrClient re = new RegistrClient();
            this.Hide();
            re.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ManagerForm re = new ManagerForm();
            this.Hide();
            re.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClientForn re = new ClientForn();
            this.Hide();
            re.Show();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CarListClient re = new CarListClient();
            SecurityContext.avtovxod = 2;
            this.Hide();
            re.Show();
        }
    }
}
