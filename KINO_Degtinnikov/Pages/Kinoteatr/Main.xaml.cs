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

namespace KINO_Degtinnikov.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Main()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (KinoteatrContext item in AllKinoteatrs)
            {
                parent.Children.Add(new Pages.Kinoteatr.Items.Item(item));
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
          MainWindow.init.frame.GoBack();
        }
    }
}
