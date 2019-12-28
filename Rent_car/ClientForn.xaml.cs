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
    /// Логика взаимодействия для ClientForn.xaml
    /// </summary>
    public partial class ClientForn : Window
    {
        public ClientForn()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OrderClient re = new OrderClient();
            this.Hide();
            re.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow re = new MainWindow();
            this.Hide();
            re.Show();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            CarListClient re = new CarListClient();
            this.Hide();
            re.Show();
        }
    }
}
