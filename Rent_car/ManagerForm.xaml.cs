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
    /// Логика взаимодействия для ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OrderList  re  = new OrderList();
            this.Hide();
            re.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClientList re = new ClientList();
            this.Hide();
            re.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CarList re = new CarList();
            this.Hide();
            re.Show();
        }

        private void button2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow re = new MainWindow();
            this.Hide();
            re.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            OrderList re = new OrderList();
            this.Hide();
            re.Show();
        }
    }
}
