﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WORDProjectUI.ViewModels;

namespace WORDProjectUI.Views.Tabs
{
    /// <summary>
    /// Interaction logic for ExamineesTab.xaml
    /// </summary>
    public partial class ExamineesTab : UserControl
    {
        public ExamineesTab()
        {
            InitializeComponent();
            DataContext = new ExamineesTabViewModel();
        }
    }
}
