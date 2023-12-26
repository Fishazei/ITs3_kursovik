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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IT_3S_Kursovik.Game.GlobalMap
{
    /// <summary>
    /// Interaction logic for GlobalMap.xaml
    /// </summary>
    public partial class GlobalMap : Page
    {
        private const int TimerInterval = 16; // Примерно 60 FPS
        private const int MoveSpeed = 5;      // Скорость персонажа

        private DateTime keyDownTime;   // Длительность удерживания клавишы
        private DateTime cooldown;      // Время начала отсчёта кулдауна
        private bool isSpaceKeyDown;    // Зажат ли пробел
        private bool isThrHook;         // Закинут ли крючок

        MapGenerator mapGenerator;  // Генератор карты и сама карта
        private HookMap myHook;     // Крючок и леска

        private readonly DispatcherTimer timer; // Общеигровой таймер

        public int points; // Очки
        int tryAvaible;    // Общее количество оставшихся попыток, изначально пять
        int games;  // Сколько осталось игр, изначально три

        MenuPage menuPage;  //Откуда пришли
        int diff;           //В каком режиме

        public GlobalMap(MenuPage menuPage, int diff)
        {
            this.menuPage = menuPage;
            this.diff = diff;

            InitializeComponent();

            CreateTexture();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(TimerInterval)
            };

            points = 0;
            tryAvaible = 5;
            games = 3;

            cooldown = DateTime.Now;
            timer.Tick += MovePlayer;
            timer.Tick += HookThr;
            isSpaceKeyDown = false;
            isThrHook = false;
            Loaded += YourPage_Loaded;
            timer.Start();
        }

        private async void YourPage_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }
        public void MovePlayer(object sender, EventArgs e)
        {
            double currentLeft = Canvas.GetLeft(movingRectangle);
            double currentTop = Canvas.GetTop(movingRectangle);

            if (Keyboard.IsKeyDown(Key.W) && currentTop - MoveSpeed > 76)
            {
                Canvas.SetTop(movingRectangle, currentTop - MoveSpeed);
                if (myHook != null) myHook.Move0(Canvas.GetLeft(movingRectangle), Canvas.GetTop(movingRectangle));
            }
            if (Keyboard.IsKeyDown(Key.S) && currentTop + movingRectangle.Width + MoveSpeed < 655)
            {
                Canvas.SetTop(movingRectangle, currentTop + MoveSpeed);
                if (myHook != null) myHook.Move0(Canvas.GetLeft(movingRectangle), Canvas.GetTop(movingRectangle));
            }
            if (Keyboard.IsKeyDown(Key.D) && currentLeft + movingRectangle.Width + MoveSpeed < 170)
            {
                Canvas.SetLeft(movingRectangle, currentLeft + MoveSpeed);
                if (myHook != null) myHook.Move0(Canvas.GetLeft(movingRectangle), Canvas.GetTop(movingRectangle));
            }
            if (Keyboard.IsKeyDown(Key.A) && currentLeft - MoveSpeed > 10)
            {
                Canvas.SetLeft(movingRectangle, currentLeft - MoveSpeed);
                if (myHook != null) myHook.Move0(Canvas.GetLeft(movingRectangle), Canvas.GetTop(movingRectangle));
            }
            //Начали замахиваться
            if (Keyboard.IsKeyDown(Key.Space) && !isSpaceKeyDown && !isThrHook && ((DateTime.Now - cooldown).TotalSeconds > 2))
            {
                isSpaceKeyDown = true;
                keyDownTime = DateTime.Now;
            }
            //Тянем назад
            if (isThrHook && Keyboard.IsKeyDown(Key.Space))
            {
                myHook.GoBack();
            }
            //Опустили крючок и начали рыбачить
            if (isThrHook && Keyboard.IsKeyDown(Key.E))
            {
                int i, j;
                for (i = 0; myHook.ycur - 45 * i > 61; i++) ;
                for (j = 0; myHook.xcur - 45 * j > 165; j++) ;

                if (i != 0 && j != 0 && i < 15 && j < 23)
                {
                    games--;
                    tryAvaible--;
                    tryAvaibleTB.Text = "Попыток " + tryAvaible.ToString() + '/' + games.ToString();
                   
                    //Запуск игры с настройками в зависимости от mapGenerator.matrix[i-1,j-1]                  
                    StartGame(mapGenerator.matrix[i - 1, j - 1]);
                    myHook.CheckMePLS -= Cheker;
                    isThrHook = false;
                    myHook.DeleteMePLS();
                    myHook = null;
                   
                    //Завершение
                    if (games == 0 || tryAvaible == 0) ExitF();
                }
            }
        }
        //Кинули крюк
        public void HookThr(object sender, EventArgs e)
        {
            if (isSpaceKeyDown && !isThrHook && Keyboard.IsKeyUp(Key.Space))
            {
                isThrHook = true;
                isSpaceKeyDown = false;


                double currentLeft = Canvas.GetLeft(movingRectangle);
                double currentTop = Canvas.GetTop(movingRectangle);

                double mouseLeft = Mouse.GetPosition(GlobalMap1).X;
                double mouseTop = Mouse.GetPosition(GlobalMap1).Y;

                TimeSpan heldTime = DateTime.Now - keyDownTime;

                myHook = new HookMap(
                    mouseLeft,
                    mouseTop,
                    currentLeft,
                    currentTop,
                    MyCanvas,
                    heldTime
                    );

                myHook.CheckMePLS += Cheker;
            }
        }

        //Проверка крюка на все венерические 
        void Cheker(double x, double y)
        {
            double currentLeft = Canvas.GetLeft(movingRectangle);
            double currentTop = Canvas.GetTop(movingRectangle);

            //Проверка на полное сматывание удочки
            if (x + 20 > currentLeft && x < currentLeft + 100)
                if (y + 20 > currentTop && y < currentTop + 100)
                {
                    myHook.CheckMePLS -= Cheker;
                    isThrHook = false;
                    myHook.DeleteMePLS();

                    //Кулдаун на пробел
                    cooldown = DateTime.Now;
                }
            //Проверка на попадание на корягу
            int i, j;
            for (i = 0; myHook.ycur + 10 - 45 * i > 61; i++) ;
            for (j = 0; myHook.xcur + 10 - 45 * j > 165; j++) ;

            if (i != 0 && j != 0 && i < 15 && j < 23)
                if (mapGenerator.matrix[i - 1, j - 1] == -1)
                {
                    myHook.CheckMePLS -= Cheker;
                    isThrHook = false;
                    myHook.DeleteMePLS();

                    //Кулдаун на пробел
                    cooldown = DateTime.Now;

                    tryAvaible--;
                    if (tryAvaible == 0) ExitF();

                    tryAvaibleTB.Text = "Попыток " + tryAvaible.ToString() + '/' + games.ToString();
                }

        }
        
        //Выход в меню
        private void ExitF()
        {
            GameOver(points);
            //Дописать выход
            NavigationService.Navigate(menuPage);
        }
        //Запуск игры
        private void StartGame(int buff)
        {
            MainGamePage mainGamePage = new MainGamePage(this, diff, buff);

            mainGamePage.GameOver += AddToRecords;

            NavigationService.Navigate(mainGamePage);
        }

        private void AddToRecords(int buff)
        {
            points += buff;
            pointsTextBlock.Text = "ОР: " + points.ToString();
        }


        private async Task GameLoop()
        {
            while (true)
            {
                await Task.Delay(10);
            }
        }

        private void CreateTexture()
        {
            mapGenerator = new MapGenerator(13, 21);
            // Устанавливаем текстуру как источник изображения для Image
            matrixImage.Source = mapGenerator.CreateTexture();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Переход в главное меню
            ExitF();
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("WASD - движение пероснажа; SPACE - забрасывание/подтягивание поплавка; E(У) - начало поклёва;\n" +
                            "Чем темнее клета - тем больше рыбы. Коричневые клетки - коряги, об которые тратятся жизни.\n" +
                            "Всего есть 5 жизней, максимум можно прорыбачить 3 раза, остальные - запасные! Удачной игры!\n");
        }

        public delegate void Handler(int alpha);
        public event Handler GameOver;
    }
}
