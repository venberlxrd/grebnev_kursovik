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
    /// Логика взаимодействия для CarsAdd.xaml
    /// </summary>
    public partial class CarsAdd : Window
    {
        public CarsAdd()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            rentcarEntities db = new rentcarEntities();
            Cars save = new Cars
            {

                Car = Car.Text,
                CarAvailable = Available.Text,
                CarCountry = Country.Text,
                CarModel = Model.Text,
                CarYear = Data.Text,
                VIN = Vin.Text,
                CarPrice = int.Parse(CarPrice.Text)
            
            };
            db.Cars.Add(save);
            db.SaveChanges();
            MessageBox.Show("Машина добавлена");
            CarList reg = new CarList();
            this.Hide();
            reg.Show();
        }

        private void CarPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CarList re = new CarList();
            this.Hide();
            re.Show();
        }
    }
}
