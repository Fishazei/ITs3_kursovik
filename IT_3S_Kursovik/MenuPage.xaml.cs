using IT_3S_Kursovik.classes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        RecordsHandler recordsHandler = new RecordsHandler();

        MainGamePage mainGamePage = null;

        public MenuPage()
        {
            InitializeComponent();
        }

        private void ButtonClickNew(object sender, RoutedEventArgs e)
        {
            DifficultyWindow difficultyWindow = new DifficultyWindow();
            difficultyWindow.ShowDialog();
            if (difficultyWindow.Difficulty == 0)
                return;
            mainGamePage = new MainGamePage(this, difficultyWindow.Difficulty);

            mainGamePage.GameOver += AddToRecords;

            NavigationService.Navigate(mainGamePage);
        }

        private void AddToRecords(int score)
        {
            Record record = new Record("avto", mainGamePage.Points());

            recordsHandler.AddRecord(record);
        }

        private void ButtonClickRecords(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
            recordsHandler.GetRecords();
        }

        private void ButtonClickFight(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
