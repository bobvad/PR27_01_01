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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        KinoteatrContext kinoteatr;
        public Add(KinoteatrContext kinoteatr = null)
        {
            InitializeComponent();

            if (kinoteatr != null)
            {
                this.kinoteatr = kinoteatr;
                name.Text = kinoteatr.Name;
                count_zal.Text = kinoteatr.CountZal.ToString();
                count.Text = kinoteatr.Count.ToString();
                bthAdd.Content = "Изменить";
            }
            else
            {
                this.kinoteatr = null;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name.Text))
                {
                    MessageBox.Show("Необходимо указать наименование");
                    return;
                }
                if (string.IsNullOrEmpty(count_zal.Text))
                {
                    MessageBox.Show("Необходимо указать количество залов");
                    return;
                }
                if (string.IsNullOrEmpty(count.Text))
                {
                    MessageBox.Show("Необходимо указать количество мест");
                    return;
                }

                if (this.kinoteatr == null)
                {
                    KinoteatrContext newKinoteatr = new KinoteatrContext(
                        0,
                        name.Text,
                        Convert.ToInt32(count_zal.Text),
                        Convert.ToInt32(count.Text)
                    );
                    newKinoteatr.Add();
                    MessageBox.Show("Запись успешно добавлена");
                }
                else
                {
                    this.kinoteatr.Name = name.Text;
                    this.kinoteatr.CountZal = Convert.ToInt32(count_zal.Text);
                    this.kinoteatr.Count = Convert.ToInt32(count.Text);
                    this.kinoteatr.Update();
                    MessageBox.Show("Запись успешно обновлена");
                }

                MainWindow.init.frame.Navigate(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильный формат числовых значений");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MainWindow.init.frame.Navigate(new Pages.Kinoteatr.Main());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Glavnai());
        }
    }
}
