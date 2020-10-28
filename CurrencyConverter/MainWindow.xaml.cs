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

namespace CurrencyConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Выход из приложения
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //Парсинг данных 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            String Respons = webClient.DownloadString("https://moskva.vbr.ru/banki/al_fa-bank/kurs-valut/usd/");
            // span id="u">79.09</span>
            usdCB.Text = System.Text.RegularExpressions.Regex.Match(Respons, @"ЦБ USD</a></td><td>([0-9]+\,[0-9]+)</td>").Groups[1].Value;
            eurCB.Text = System.Text.RegularExpressions.Regex.Match(Respons, @"ЦБ EUR</a></td><td>([0-9]+\,[0-9]+)</td>").Groups[1].Value;

           
        }
    }
}
