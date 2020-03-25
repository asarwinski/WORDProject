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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WORDProjectClassLib.DB;
using WORDProjectClassLib.Models;
using WORDProjectClassLib.Pdf;
using WORDProjectUI.Utils;

namespace WORDProjectUI.Views.Tabs
{
    /// <summary>
    /// Interaction logic for CreatePdfTab.xaml
    /// </summary>
    public partial class CreatePdfTab : UserControl, INotifyPropertyChanged
    {
        DataBase db;

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged();
                OnPropertyChanged("ButtonEnabled");
            }
        }

        public bool ButtonEnabled
        {
            get 
            {
                return Category != null;
            }
        }

        public CreatePdfTab()
        {
            InitializeComponent();
            db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Internet));
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = ".pdf";
            fileDialog.CheckFileExists = false;

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                var exams = await db.GetFinishedExams(category: Category);
                PdfCreator.Create(exams, fileDialog.FileName);     
            }      
            Category = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
