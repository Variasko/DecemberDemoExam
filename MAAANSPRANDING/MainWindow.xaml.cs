using System.Windows;

namespace MAAANSPRANDING
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginEnter.Text;
            string password = passwordEnter.Password;

            int role = Authorization(login, password);

            switch (role)
            {
                case -1:
                    MessageBox.Show("Неверный логин или пароль",
                        "Ошибка авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    break;
                case 1:
                    MessageBox.Show("Администратор");
                    break;
                case 2:
                    MessageBox.Show("Сотрудник");
                    break;
                case 3:
                    ClientOrderWindow c = new ClientOrderWindow();
                    c.Show();
                    this.Close();
                    break;
            }
        }

        private int Authorization(string login, string password)
        {
            if (login != password)
            {
                return -1;
            }

            switch (login)
            {
                case "admin":
                    return 1;
                case "emp":
                    return 2;
                case "user":
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
