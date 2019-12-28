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
    /// Логика взаимодействия для CarList.xaml
    /// </summary>
    public partial class CarList : Window
    {
        public CarList()
        {
            InitializeComponent();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Carlistgrid.ItemsSource = dtClient.DefaultView;
        }
        DataTable dtClient = GetReList();
        public static DataTable GetReList()
        {
            rentcarEntities db = new rentcarEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Автомобиль");
            dtClient.Columns.Add("Модель");
            dtClient.Columns.Add("Год выпуска");
            dtClient.Columns.Add("Страна изготовитель");
            dtClient.Columns.Add("VIN");
            dtClient.Columns.Add("Статус");
           
            var Query = db.Cars;

            foreach (var rel in Query)
            {
             
                {
                    dtClient.Rows.Add(rel.idCar, rel.Car, rel.CarModel, rel.CarYear, rel.CarCountry, rel.VIN, rel.CarAvailable);
                }
            }
            return dtClient;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CarsAdd re = new CarsAdd();
            this.Hide();
            re.Show();
           
        }

      

        

        private void Carlistgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idClient = int.Parse((dtClient.Rows[Carlistgrid.SelectedIndex].ItemArray[0].ToString()));

                CurrentCar cur = new CurrentCar();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Здесь ничего нет");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManagerForm cur = new ManagerForm();
            this.Hide();
            cur.Show();
        }
    }
}
