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
            try
            {

                rentcarEntities db = new rentcarEntities();
                var rol = db.Users.Where(us => us.Login == Login.Text && us.Password == Password.Text).FirstOrDefault().Role;
                var f = db.Users.Where(us => us.Login == Login.Text && us.Password == Password.Text).FirstOrDefault().IdUser;

                if (rol == "Client")
                {
                    ClientForn re = new ClientForn();
                    this.Hide();
                    SecurityContext.idClient = f;
                    re.Show();
                }
                else if (rol == "Manager")
                {
                    ManagerForm re = new ManagerForm();
                    this.Hide();
                    re.Show();
                }





            }
            catch
            {
                MessageBox.Show("Данный логин уже существует");
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
    }
}
