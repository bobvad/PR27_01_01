using KINO_Degtinnikov.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select(); 
        AfishaContext currentAfisha; 
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();
            kinoteatrs.DisplayMemberPath = "Name";
            foreach (var item in AllKinoteatrs)
                kinoteatrs.Items.Add(item);
            if (afisha != null)
            {
                currentAfisha = afisha;
                //kinoteatrs.SelectedItem = kinoteatrs.Items.Cast<KinoteatrContext>()
                //                   .FirstOrDefault(k => k.Id == afisha.id_films);
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.Id == currentAfisha.id_films);
                name.Text = afisha.Name;
                Date.SelectedDate = afisha.time;
                Time.Text = afisha.time.ToString("HH:mm:ss");
                price.Text = afisha.price.ToString();
                bthAdd.Content = "Изменить";
            }
            else
            {
                kinoteatrs.SelectedIndex = -1; 
            }
        }
        private void AddRecord(object sender, RoutedEventArgs e)
        {
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Необходимо ввести название.");
                    return;
                }
                if (kinoteatrs.SelectedItem == null)
                {
                    MessageBox.Show("Выберите кинотеатр.");
                    return;
                }
                if (Date.SelectedDate == null)
                {
                    MessageBox.Show("Укажите дату.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Time.Text))
                {
                    MessageBox.Show("Укажите время.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(price.Text) || !decimal.TryParse(price.Text, out decimal priceValue))
                {
                    MessageBox.Show("Некорректная цена.");
                    return;
                }
                if (!TimeSpan.TryParse(Time.Text, out TimeSpan time))
                {
                    MessageBox.Show("Неверный формат времени.");
                    return;
                }

                DateTime fullDateTime = Date.SelectedDate.Value.Date + time;
                var selectedKinoteatr = kinoteatrs.SelectedItem as KinoteatrContext;

                if (currentAfisha == null)
                {
                    AfishaContext newAfisha = new AfishaContext(
                       0,                     
                       name.Text,              
                       selectedKinoteatr.Id,  
                       fullDateTime,         
                       priceValue             
                    );
                    newAfisha.Add();
                    MessageBox.Show("Новая запись успешно добавлена!");
                }
                else
                {
                    currentAfisha.Name = name.Text;
                    currentAfisha.id_films = selectedKinoteatr.Id;
                    currentAfisha.time = fullDateTime;
                    currentAfisha.price = priceValue;
                    currentAfisha.Update();
                    MessageBox.Show("Запись успешно обновлена!");
                }

                MainWindow.init.frame.Navigate(new Main());
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Afisha.Main());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Glavnai());
        }
    }
}
