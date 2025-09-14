using System.Windows;
namespace KINO_Degtinnikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            frame.Navigate(new Pages.Kinoteatr.Add());
        }
    }
}
