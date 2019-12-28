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
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        public OrderList()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ManagerForm re = new ManagerForm();
            this.Hide();
            re.Show();
        }
        DataTable dtClient = GetReList();
        private void OrderLi_Loaded(object sender, RoutedEventArgs e)
        {
            OrderLi.ItemsSource = dtClient.DefaultView;
        }
        public static DataTable GetReList()
        {

            rentcarEntities db = new rentcarEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Машина");
            dtClient.Columns.Add("Модель");
            dtClient.Columns.Add("Статус аренды");
            dtClient.Columns.Add("Время аренды");
            dtClient.Columns.Add("ФИО");
            dtClient.Columns.Add("Номер телефона");
            var query = from order in db.Order
                        join car in db.Cars on order.IdCar equals car.idCar
                        join client in db.Users on order.idClient equals client.IdUser
                        select new
                        {   order.idOrder,
                            car = car.Car,    
                            mod = car.CarModel,
                            order.RentStatus,
                            order.RentTime,
                            FIO = client.SecondName + " " + client.Name + " " + client.MiddlName,
                            Phone = client.PhoneNumber
                        };


            foreach (var rel in query)
            {

                dtClient.Rows.Add(rel.idOrder,rel.car, rel.mod, rel.RentStatus, rel.RentTime,rel.FIO,rel.Phone);

            }
            return dtClient;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddOrder re = new AddOrder();
            this.Hide();
            re.Show();
        }

        private void OrderLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idOrder = int.Parse((dtClient.Rows[OrderLi.SelectedIndex].ItemArray[0].ToString()));

                CurrendOrder cur = new CurrendOrder();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Здесь ничего нет");
            }
        }

        private void OrderLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
