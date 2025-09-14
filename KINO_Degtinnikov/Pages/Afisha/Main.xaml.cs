using KINO_Degtinnikov.Classes;
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

namespace KINO_Degtinnikov.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<AfishaContext> AllKinoteatrs = AfishaContext.Select();
        Main main;
        public Main()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (AfishaContext item in AllKinoteatrs)
            {
                parent.Children.Add(new Pages.Afisha.Items.Item(item,main));
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.GoBack();
        }
    }
}
