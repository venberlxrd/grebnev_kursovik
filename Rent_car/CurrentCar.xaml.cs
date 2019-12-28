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
    /// Логика взаимодействия для CurrentCar.xaml
    /// </summary>
    public partial class CurrentCar : Window
    {
        public CurrentCar()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            Cars car = db.Cars.Find(SecurityContext.idClient);
            car.CarModel = Carmodel.Text;
            car.Car = Car.Text;
            car.CarAvailable= CarAvailable.Text;
            car.CarCountry = CarCountry.Text;
            car.CarYear = CarYear.Text;
            car.VIN = VIN.Text;
            db.Cars.Create();
            db.SaveChanges();
            CarList re = new CarList();
            this.Hide();
            re.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            var car_ = db.Cars.Find(SecurityContext.idClient);
            Car.Text = car_.Car;
            Carmodel.Text = car_.CarModel;
            CarAvailable.Text = car_.CarAvailable;
            CarCountry.Text = car_.CarCountry;
            CarYear.Text = car_.CarYear;
            VIN.Text = car_.VIN;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            var car = db.Cars.Find(SecurityContext.idClient);
            db.Cars.Remove(db.Cars.Where(dr => dr.idCar == SecurityContext.idClient).FirstOrDefault());
            db.SaveChanges();
            CarList re = new CarList();
            this.Hide();
            re.Show();
        }
    }
}
