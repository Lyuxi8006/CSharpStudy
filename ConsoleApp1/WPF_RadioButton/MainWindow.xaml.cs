﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_RadioButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void STK_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++) 
            {
                var rdo = new RadioButton();
                rdo.Content = "Radio" + i;
                rdo.Checked += Rdo_Checked; ;
                STK.Children.Add(rdo);
            }
        }

        private void Rdo_Checked(object sender, RoutedEventArgs e)
        {
            var rdo = sender as RadioButton;
            rdo.Foreground = new SolidColorBrush(Colors.Blue);
        }
    }
}
