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
        AfishaContext item;
        public Item(AfishaContext item, Main main)
        {
            InitializeComponent();
            kinoteatr.Text = AllKinoteatrs.Find(x => x.Id == item.IdKinoteatr).Name;
            name.Text = item.Name;
            Date.Text = item.Time.ToString("yyyy-MM-dd");
            time.Text = item.Time.ToString("HH:mm");
            Price.Text = item.Price.ToString();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Add(this.item));
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
               item.Delete();
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
