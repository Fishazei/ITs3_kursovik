using IT_3S_Kursovik.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading; //Таймер

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Interaction logic for MainGamePage.xaml
    /// </summary>
    public partial class MainGamePage : Page
    {
        MenuPage menuPage = null;

        private TimeSpan duration = TimeSpan.FromMinutes(1);
        private DispatcherTimer timer;
        private DateTime startTime;
        private DateTime pauseTime;
        private Options myOptions;

        GameState gameState;

        public MainGamePage(MenuPage menuPage, int diff)
        {
            InitializeComponent();
            this.menuPage = menuPage;
            
            myOptions.mod = diff;
            myOptions.spawnProd = 5;
            myOptions.fishChan = 50;

            if (myOptions.mod == 2) overlayGrid.Visibility = Visibility.Visible;
            else if (myOptions.mod == 3)
            {

            }

            DinB.IsEnabled = false;
            DinB.Visibility = Visibility.Collapsed;
            gameState = new GameState(myOptions, RiverHold, overlayGrid, rec1, rope);
            gameState.ScoreUp += UpdateIO;
            gameState.TimeToDinamite += DBActivate;

            // Создание таймера
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            //Привязка к таймеру событий
            timer.Tick += TimerTick;
            timer.Tick += gameState.MovePlayer;
            // Начальная установка времени
            startTime = DateTime.Now;
            // Запуск таймера
            timer.Start();
            StartAnimation();
        }

        public int Points()
        {
            return gameState.Score;
        }

        private void UpdateIO(int score)
        {
            pointsTextBlock.Text = "OР: " + score.ToString();
        }

        private async Task GameLoop()
        {
            while (gameState.status == GStatus.Go)
            {
                await Task.Delay(10);
                gameState.GenerateNewFish();
                gameState.MoveAll();
            }
        }

        private async void GameCanvasLoaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        #region Timer
        private void TimerTick(object sender, EventArgs e)
        {
            // Расчет оставшегося времени
            TimeSpan elapsed = DateTime.Now - startTime;

            // Проверка, истекло ли общее время в минутy
            if (elapsed >= duration)
            {
                // Таймер истек, делаем необходимые действия
                timer.Stop();
                gameState.status = GStatus.End;
                NavigationService.Navigate(menuPage);
                GameOver(gameState.Score);
            }
        }
        //Старт-пауза таймера обратного отсчёта
        private void ToggleCountdown()
        {
            gameState.status = gameState.status == GStatus.Pause ? GStatus.Go : GStatus.Pause;
            PauseOrResumeAnimation();

            if (gameState.status == GStatus.Pause) {
                pauseTime = DateTime.Now;
                timer.Stop();
            }
            else 
            {
                startTime += DateTime.Now - pauseTime;
                timer.Start();

                GameLoop();
            }
        }

        //Анимация таймера
        private void StartAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Begin();
        }
        private void PauseOrResumeAnimation()
        {
            if (gameState.status == GStatus.Pause) ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Pause();
            else ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Resume();
        }

        #endregion

        //События обработки нажатий клавиш и кнопок
        private void PauseButtonClick(object sender, RoutedEventArgs e)
        {
            ToggleCountdown();
            PauseMenuUC.Visibility = PauseMenuUC.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

        }
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                // При нажатии таба выполнить тот же код, что и при нажатии кнопки
                PauseButtonClick(null, null);
            }
            
        }

        //Динамит
        private void DClick(object sender, RoutedEventArgs e)
        {
            gameState.UseDinamite();
            DinB.IsEnabled = false;
            DinB.Visibility = Visibility.Collapsed;
            UpdateIO(gameState.Score);
        }
        private void DBActivate()
        {
            DinB.IsEnabled = true;
            DinB.Visibility = Visibility.Visible;
        }

        public delegate void Handler(int alpha);
        public event Handler GameOver;
    }
}
