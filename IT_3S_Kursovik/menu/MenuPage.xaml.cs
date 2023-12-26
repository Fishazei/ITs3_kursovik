using IT_3S_Kursovik.classes;
using IT_3S_Kursovik.Game.GlobalMap;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        RecordsHandler recordsHandler = new RecordsHandler();
        Record record;

        //MainGamePage mainGamePage = null;

        GlobalMap mainGlobalMap = null;

        public MenuPage()
        {
            record = new Record("Avto", 0);
            InitializeComponent();

            rec.Closed += recUCClosed;
        }

        private void ButtonClickNew(object sender, RoutedEventArgs e)
        {
            DifficultyWindow difficultyWindow = new DifficultyWindow();
            difficultyWindow.ShowDialog();
            if (difficultyWindow.Difficulty == 0)
                return;
            //mainGamePage = new MainGamePage(this, difficultyWindow.Difficulty);

            //mainGamePage.GameOver += AddToRecords;

            //NavigationService.Navigate(mainGamePage);

            mainGlobalMap = new GlobalMap(this, difficultyWindow.Difficulty);

            mainGlobalMap.GameOver += AddToRecords;

            NavigationService.Navigate(mainGlobalMap);
        }

        private void AddToRecords(int score)
        {
            record.points = mainGlobalMap.points;

            if(record.points > 0)
                recordsHandler.AddRecord(record);
        }

        private void ToggleButtonsState(bool isEnable)
        {
            SayMyName.IsEnabled = isEnable;
            NewGame.IsEnabled = isEnable;
            Records.IsEnabled = isEnable;
            Manual.IsEnabled = isEnable;
            Exit.IsEnabled = isEnable;
        }

        private void ButtonClickRecords(object sender, RoutedEventArgs e)
        {
            rec.Records = recordsHandler.GetRecords();
            ToggleButtonsState(false);
            rec.Visibility = Visibility.Visible;
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonsState(false);
            //Расписать что да как!
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SayMyName.Text != null) record.name = SayMyName.Text;
            else { record.name = "Avto"; SayMyName.Text = "Avto"; }
        }

        private void recUCClosed(object sender, EventArgs e)
        {
            ToggleButtonsState(true);
        }
    }
}
