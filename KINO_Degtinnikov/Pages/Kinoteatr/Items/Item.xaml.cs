using KINO_Degtinnikov.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KINO_Degtinnikov.Pages.Kinoteatr.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        KinoteatrContext Kinoteatr;
        public Item(KinoteatrContext Kinoteatr)
        {
            InitializeComponent();
            name.Text = Kinoteatr.Name;
            count_zal.Text = Kinoteatr.CountZal.ToString();
            count.Text = Kinoteatr.Count.ToString();
            this.Kinoteatr = Kinoteatr;
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                    Kinoteatr.Delete();

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
        private void Update(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Add(this.Kinoteatr));
        }
    }
}
