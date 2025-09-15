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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KINO_Degtinnikov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Glavnai.xaml
    /// </summary>
    public partial class Glavnai : Page
    {
        public Glavnai()
        {
            InitializeComponent();
        }

        private void Kino(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Kinoteatr.Add());
        }

        private void Afisha(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Afisha.Add());
        }
    }
}
