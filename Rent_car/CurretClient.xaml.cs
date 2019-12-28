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
    /// Логика взаимодействия для CurretClient.xaml
    /// </summary>
    public partial class CurretClient : Window
    {
        public CurretClient()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            Users us = db.Users.Find(SecurityContext.idClient);
            us.Name = Name.Text;
            us.MiddlName = MiddlName.Text;
            us.SecondName = SecondName.Text;
            us.PhoneNumber = Phone.Text;
            us.Login = Login.Text;
            us.Password = Password.Text;
            
            db.Users.Create();
            db.SaveChanges();
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            var users = db.Users.Find(SecurityContext.idClient);
            Name.Text = users.Name;
            SecondName.Text = users.SecondName;
            MiddlName.Text = users.MiddlName;
            Phone.Text = users.PhoneNumber;
            Login.Text = users.Login;
            
            Password.Text = users.Password;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            var users = db.Users.Find(SecurityContext.idClient);
            db.Users.Remove(db.Users.Where(dr => dr.IdUser == SecurityContext.idClient).FirstOrDefault());
            db.SaveChanges();
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }
    }
}
