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
    /// Логика взаимодействия для OrderClient.xaml
    /// </summary>
    public partial class OrderClient : Window
    {
        public OrderClient()
        {
            InitializeComponent();
        }
        DataTable dtClient = GetReList();

        private void OrderClientLi_Loaded(object sender, RoutedEventArgs e)
        {
            OrderClientLi.ItemsSource = dtClient.DefaultView;
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
            var query = from order in db.Order
                        join car in db.Cars on order.IdCar equals car.idCar
                        join client in db.Users on order.idClient equals client.IdUser
                        select new
                        {
                            order.idClient,
                            order.idOrder,
                            car = car.Car,
                            mod = car.CarModel,
                            order.RentStatus,
                            order.RentTime,
                        };
            foreach (var rel in query)
            {
                if (rel.idClient == SecurityContext.idClient)
             
                dtClient.Rows.Add(rel.idOrder,rel.car, rel.mod, rel.RentStatus, rel.RentTime);
                 
            }
            return dtClient;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ClientForn re = new ClientForn();
            this.Hide();
            re.Show();
        }

        private void OrderClientLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
