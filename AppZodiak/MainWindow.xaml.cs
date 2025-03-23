using System;
using System.Collections.Generic;
using System.Data;
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

namespace AppZodiak
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isTodayBirthday(DateTime birthDate)
        {
            if (birthDate.Day == DateTime.Now.Day &&
                birthDate.Month == DateTime.Now.Month)
            {
                return true;
            }

            return false;
        }

        private void onClickCountZodiak(object sender, RoutedEventArgs e)
        {
            if (dataPicker.SelectedDate == null)
            {
                MessageBox.Show("Виберіть дату народження!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dataPicker.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Виберіть коректну дату народження!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime birthDate = dataPicker.SelectedDate.Value;
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age)) age--;

            if (isTodayBirthday(birthDate))
                CongratulaionText.Visibility = Visibility.Visible;
            else CongratulaionText.Visibility = Visibility.Hidden;


            WesternZodiac westernZodiac = new WesternZodiac();
            ChineseZodiac chineseZodiac = new ChineseZodiac();

            string zodiacSignResult = westernZodiac.getZodiacSign(birthDate);
            string chineseZodiacResult = chineseZodiac.getZodiacSign(birthDate);

            if (age == 0)
                AgeResult.Text = "Менше року";
            else AgeResult.Text = $"{age} років";
            ZodiacResult.Text = $"Знак зодіаку: {zodiacSignResult}";
            ChineseZodiacResult.Text = $"Китайський зодіак: {chineseZodiacResult}";

            ResultPanel.Visibility = Visibility.Visible;
        }
    }
}
