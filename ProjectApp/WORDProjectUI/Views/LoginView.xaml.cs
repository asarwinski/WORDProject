using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WORDProjectUI.ViewModels;
using WORDProjectClassLib.DB;
using WORDProjectUI.Utils;

namespace WORDProjectUI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, INotifyPropertyChanged
    {
        DataBase db;

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
                OnPropertyChanged("ButtonEnabled");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
                OnPropertyChanged("ButtonEnabled");
            }
        }


        public bool ButtonEnabled
        {
            get
            {
                return !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Login);
            }
        }
        public LoginView()
        {
            InitializeComponent();
            DataContext = this;
            db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Internet));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = db.CheckPassword(Login, Password);
                if (result)
                {
                    var main = new MainWindow();
                    this.Hide();
                    main.Show();
                    this.Close();
                }
                else
                {
                    Login = null;
                    Password = null;
                    WrongPassword.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                MessageBox.Show("Błąd połączenia z serverem SQL.");
            }
        }
    }
}
