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
            rentcarEntities db = new rentcarEntities();  // подключение бд
            Order save = new Order // создание класса SAVE
            {
                
                IdCar = int.Parse(dtCar.Rows[CarLi.SelectedIndex].ItemArray[0].ToString()), // Из класса SAVE выбираются 4 переменные, в которые добавляются 4 переменные которые ввел пользователь
                idClient = int.Parse(dtClient.Rows[ClientLi.SelectedIndex].ItemArray[0].ToString()),
            RentTime = RenTime.Text

            };
            
            db.Order.Add(save); // далее идет добавление и сохранение данных в бд
            db.SaveChanges();
            MessageBox.Show("Заказ добавлен");
            if (SecurityContext.avtovxod == 3)
            {
                OrderList reg = new OrderList();
               
                this.Hide();
                reg.Show();
            }
            if (SecurityContext.avtovxod == 1)
            {
                OrderClient reg = new OrderClient();
                this.Hide();
                reg.Show();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityContext.avtovxod == 3)
            {
                OrderList reg = new OrderList();
               
                this.Hide();
                reg.Show();
            }
            if (SecurityContext.avtovxod == 1)
            {
                OrderClient reg = new OrderClient();
                this.Hide();
                reg.Show();
            }
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
            var Query = db.Users; // Запрос на выборку данных из таблицы Users

            foreach (var rel in Query) // Отображение данных в DataGrid 
            { if (SecurityContext.avtovxod == 3) // Вошел менеджер
                {
                    if (rel.Role == "Client")  // Отображение только клиентов
                        dtClient.Rows.Add(rel.IdUser, rel.SecondName, rel.Name, rel.MiddlName, rel.PhoneNumber);
                }
                if (SecurityContext.avtovxod == 1) // Вошел клиент
                {
                    if (SecurityContext.idClient == rel.IdUser) // Клиент видит только себя
                    {
                        if (rel.Role == "Client") // Отображается только клиент
                            dtClient.Rows.Add(rel.IdUser, rel.SecondName, rel.Name, rel.MiddlName, rel.PhoneNumber);

                    }
                }
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
            dtClient.Columns.Add("Цена");
            dtClient.Columns.Add("Стоимость");


            var Query = db.Cars; // Выбираются данные из таблицы Автомобили

            foreach (var rel in Query)
            {

                dtClient.Rows.Add(rel.idCar, rel.Car, rel.CarModel, rel.CarYear, rel.CarCountry, rel.VIN, rel.CarPrice);

            }
            return dtClient;
        }

        private void RentPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClientLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RenTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RenStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

