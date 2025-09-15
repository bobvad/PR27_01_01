using KINO_Degtinnikov.Classes;
using KINO_Degtinnikov.Modell;
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

namespace KINO_Degtinnikov.Pages.Afisha.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        List<AfishaContext> AllKinoteatrs = AfishaContext.Select();
        List<KinoteatrContext> All = KinoteatrContext.Select(); 
        AfishaContext items;
        public Item(AfishaContext item, Main main)
        {
            InitializeComponent();

            var allKinoteatrs = KinoteatrContext.Select();

            var selectedKinoteatr = allKinoteatrs.FirstOrDefault(k => k.Id == item.id_films);

            kinoteatr.Text = selectedKinoteatr?.Name ?? "Неизвестный кинотеатр";
            name.Text = item.Name;
            Date.Text = item.time.ToString("yyyy-MM-dd");
            time.Text = item.time.ToString("HH:mm");
            Price.Text = item.price.ToString();
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Add(this.items));
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
               items.Delete();
                MessageBox.Show("Запись успешно удалена");
                if (Parent is Panel parentPanel)
                {
                    parentPanel.Children.Remove(this);
                }
                else if (Parent is ItemsControl itemsControl)
                {
                    itemsControl.Items.Remove(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
    }
}
