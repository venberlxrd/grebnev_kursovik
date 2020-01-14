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
    /// Логика взаимодействия для CurrendOrder.xaml
    /// </summary>
    public partial class CurrendOrder : Window
    {
        public CurrendOrder()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            var order = db.Order.Find(SecurityContext.idOrder);
            RenStatus.Text = order.RentStatus;
            Rentime.Text = order.RentTime;

            CarLi.ItemsSource = dtCar.DefaultView;
            ClietnLi.ItemsSource = dtClient.DefaultView;

            for (int i = 0; i < dtClient.Rows.Count; i++)
            {
                if (int.Parse(dtClient.Rows[i].ItemArray[0].ToString()) == order.idClient)
                {
                    ClietnLi.SelectedIndex = i;
                }
            }
            for (int i = 0; i < dtCar.Rows.Count; i++)
            {
                if (int.Parse(dtCar.Rows[i].ItemArray[0].ToString()) == order.IdCar)
                {
                    CarLi.SelectedIndex = i;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            { if (Rentime.Text != "" && RenStatus.Text != "")
                {
                    rentcarEntities db = new rentcarEntities();
                    var order = db.Order.Find(SecurityContext.idOrder);
                    order.IdCar = int.Parse(dtCar.Rows[CarLi.SelectedIndex].ItemArray[0].ToString());
                    order.idClient = int.Parse(dtClient.Rows[ClietnLi.SelectedIndex].ItemArray[0].ToString());
                    order.RentTime = Rentime.Text;
                    order.RentStatus = RenStatus.Text;
                    db.Order.Create();
                    db.SaveChanges();
                    OrderList re = new OrderList();
                    this.Hide();
                    re.Show();
                }
            else
                {
                    MessageBox.Show("Вы заполнили не все поля");
                }
            }
            catch
            {
                MessageBox.Show("Вы заполнили не все поля");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            Order order = db.Order.Find(SecurityContext.idOrder);
            db.Order.Remove(db.Order.Where(dr => dr.idOrder == SecurityContext.idOrder).FirstOrDefault());
            db.SaveChanges();
            OrderList re = new OrderList();
            this.Hide();
            re.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OrderList re = new OrderList();
            this.Hide();
            re.Show();
        }
        DataTable dtClient = GetClientList();
        DataTable dtCar = GetCarList();
        private void CarLi_Loaded(object sender, RoutedEventArgs e)
        {
            CarLi.ItemsSource = dtCar.DefaultView;
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
                if (rel.Role == "Client")
                    dtClient.Rows.Add(rel.IdUser, rel.SecondName, rel.Name, rel.MiddlName, rel.PhoneNumber);

            }
            return dtClient;
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

                dtClient.Rows.Add(rel.idCar, rel.Car, rel.CarModel, rel.CarYear, rel.CarCountry, rel.VIN);

            }
            return dtClient;
        }

        private void ClietnLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClietnLi.ItemsSource = dtClient.DefaultView;
        }
    }
}
