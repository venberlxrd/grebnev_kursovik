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
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Window
    {
        public ClientList()
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
        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ClientLi.ItemsSource = dtClient.DefaultView;
        }
        public static DataTable GetReList()
        {
            rentcarEntities db = new rentcarEntities();
            DataTable dtClient = new DataTable();
            dtClient.Columns.Add("id");
            dtClient.Columns.Add("Имя");
            dtClient.Columns.Add("Фамилия");
            dtClient.Columns.Add("Отчество");
            dtClient.Columns.Add("Номер телефона");
            dtClient.Columns.Add("Логин");
            dtClient.Columns.Add("Пароль");
            dtClient.Columns.Add("Роль");
            var Query = db.Users;
            
            foreach (var rel in Query)
            {
                if (rel.Role == "Client")
                {
                    dtClient.Rows.Add(rel.IdUser, rel.Name, rel.SecondName, rel.MiddlName, rel.PhoneNumber, rel.Login, rel.Password, rel.Role);
                }
            }
            return dtClient;
        }

        private void ClientLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClientLi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SecurityContext.idClient = int.Parse((dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString()));

                CurretClient cur = new CurretClient();
                this.Hide();
                cur.Show();
            }
            catch
            {
                MessageBox.Show("Здесь ничего нет");
            }
        }
    }
}
