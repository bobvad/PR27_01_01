using System.Windows;
namespace KINO_Degtinnikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate();
        }
    }
}
