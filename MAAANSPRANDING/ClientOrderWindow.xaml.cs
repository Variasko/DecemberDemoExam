using MAAANSPRANDING.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MAAANSPRANDING
{
    /// <summary>
    /// Логика взаимодействия для ClientOrderWindow.xaml
    /// </summary>
    public partial class ClientOrderWindow : Window
    {
        private List<Order> _orders = new List<Order>();
        public ClientOrderWindow()
        {
            InitializeComponent();

            _orders = new Base().ReadObjectFromFile();

            if (_orders != null)
            {
                dataGrid.ItemsSource = _orders;
            }
            else
            {
                dataGrid.ItemsSource = new Base().GenerateOrders();
                new Base().WriteObjectToFile(new Base().GenerateOrders());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var existingOrder = (sender as Button).DataContext as Order;

            ClientAddEditOrderWindow c = new ClientAddEditOrderWindow(existingOrder);
            c.Show();
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ClientAddEditOrderWindow c = new ClientAddEditOrderWindow(null);
            c.Show();
            Close();
        }
    }
}
