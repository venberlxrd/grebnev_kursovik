using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            Order save = new Order
            {
                RentStatus = RenStatus.Text,
                RentTime = RenTime.Text

        };
            save.IdCar = int.Parse(dtCar.Rows[CarLi.SelectedIndex].ItemArray[0].ToString());
            save.idClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString());
            db.Order.Add(save);
            db.SaveChanges();
            MessageBox.Show("Заказ добавлен");
            OrderList reg = new OrderList();
            this.Hide();
            reg.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OrderList reg = new OrderList();
            this.Hide();
            reg.Show();
        }
        DataTable dtClient = GetClientList();
        DataTable dtCar = GetCarList();
        private void ClientLi_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }
        public static DataTable GetClientList()
        {
            rentcarEntities db = new rentcarEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Фамилия");
            dtClient.Columns.Add("Имя");
            dtClient.Columns.Add("Отчество");
            dtClient.Columns.Add("Номер телефона");
            var Query = db.Users;

            foreach (var rel in Query)
            {
                if(rel.Role == "Client")
                dtClient.Rows.Add(rel.IdUser, rel.SecondName, rel.Name, rel.MiddlName, rel.PhoneNumber);

            }
            return dtClient;
        }

        private void CarLi_Loaded(object sender, RoutedEventArgs e)
        {
            CarLi.ItemsSource = dtCar.DefaultView;
        }

        public static DataTable GetCarList()
        {
            rentcarEntities db = new rentcarEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Машина");
            dtClient.Columns.Add("Модель");
            dtClient.Columns.Add("Год выпуска");
            dtClient.Columns.Add("Страна");
            dtClient.Columns.Add("VIN");
            var Query = db.Cars;

            foreach (var rel in Query)
            {
               
                    dtClient.Rows.Add(rel.idCar, rel.Car, rel.CarModel, rel.CarYear, rel.CarCountry,rel.VIN);

            }
            return dtClient;
        }
    }
}

