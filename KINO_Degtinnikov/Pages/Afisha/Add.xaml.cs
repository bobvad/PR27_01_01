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
        List<AfishaContext> AllAfisha = AfishaContext.Select();
        AfishaContext afisha;

        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach (var item in AllAfisha)
                kinoteatrs.Items.Add(item);

            kinoteatrs.Items.Insert(0, "Выберите кинотеатр...");
            kinoteatrs.SelectedIndex = 0;

            if (afisha != null)
            {
                this.afisha = afisha;
                int selectedIndex = AllAfisha.FindIndex(x => x.Id == afisha.Id);
                kinoteatrs.SelectedIndex = selectedIndex + 1;

                name.Text = afisha.Name;
                Date.SelectedDate = afisha.Time.Date;
                Time.Text = afisha.Time.ToString("HH:mm");
                price.Text = afisha.Price.ToString();
                bthAdd.Content = "Изменить";
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
                if (kinoteatrs.SelectedIndex == 0)
                {
                    MessageBox.Show("Выберите кинотеатр");
                    return;
                }
                if (Date.SelectedDate == null)
                {
                    MessageBox.Show("Необходимо указать дату");
                    return;
                }
                if (string.IsNullOrEmpty(Time.Text))
                {
                    MessageBox.Show("Необходимо указать время");
                    return;
                }
                if (string.IsNullOrEmpty(price.Text) || !int.TryParse(price.Text, out int priceValue)) // Исправлено на int
                {
                    MessageBox.Show("Необходимо указать корректную стоимость");
                    return;
                }

                if (!TimeSpan.TryParse(Time.Text, out TimeSpan time))
                {
                    MessageBox.Show("Неверный формат времени");
                    return;
                }

                DateTime fullDateTime = Date.SelectedDate.Value.Date + time;

                if (this.afisha == null)
                {
                    AfishaContext newAfisha = new AfishaContext(
                        (kinoteatrs.SelectedItem as KinoteatrContext).Id,
                        name.Text,
                        fullDateTime,
                        priceValue 
                    );
                    newAfisha.Add();
                    MessageBox.Show("Запись успешно добавлена");
                }
                else
                {
                    this.afisha.IdKinoteatr = (kinoteatrs.SelectedItem as KinoteatrContext).Id;
                    this.afisha.Name = name.Text;
                    this.afisha.Time = fullDateTime;
                    this.afisha.Price = priceValue; 
                    this.afisha.Update();
                    MessageBox.Show("Запись успешно обновлена");
                }

                MainWindow.init.frame.Navigate(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
