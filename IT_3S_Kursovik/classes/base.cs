﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.XPath;

namespace IT_3S_Kursovik.classes
{
    public enum FStatus
    {
        Right,
        Left,
        Caught,
        Delivered,
        GoAway
    }
    public enum FType
    {
        Som,
        Karp,
        Sudak,
        Dinamite,
        Trash1,
        Trash2,
        Sus
    }
    public enum GStatus
    {
        Go,
        Pause,
        End
    }
    //Изображения. их загрузка
    internal static class Images
    {
        private static readonly Dictionary<FType, ImageSource> Source = new()
        {
            {FType.Karp, LoadImage("assets/waterthings/f1.png")},
            {FType.Sudak, LoadImage("assets/waterthings/f2.png")},
            {FType.Som, LoadImage("assets/waterthings/f3.png")},
            {FType.Dinamite, LoadImage("assets/waterthings/d.png")},
            {FType.Sus, LoadImage("assets/waterthings/tr3.png")},
            {FType.Trash1, LoadImage("assets/waterthings/tr2.png")},
            {FType.Trash2, LoadImage("assets/waterthings/tr.png")}
        };
        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
        }
        public static ImageSource GetImage(FType type)
        {
            return Source[type];
        }
    }
    /// <summary>
    ///  fishChan - от 0 до 100, spawnProd - от 0 до 100
    /// </summary>
    public struct Options
    {
        public int spawnProd;   //Продуктивность спавнера рыбы
        public int fishChan;    //Шанс спавна именно рыбы
        public int mod;         //Мод от 1 до 3 (1 - вечер, 2 - утро, 3 - ночь)
    }

    //Отвечает за создание рыбов
    internal class FishGenerator
    {
        private Canvas canvas;
        private Random random;
        private Options options;

        //Очки за рыб
        static readonly Dictionary<FType, int > Ribis = new()
        {
            {FType.Som,       1000 },
            {FType.Karp ,     200 },
            {FType.Sudak ,    300 },
            {FType.Dinamite , 40 },
            {FType.Sus ,      -666 },
            {FType.Trash1 ,   -100 },
            {FType.Trash2 ,   -200 }
        };

        public FishGenerator(Canvas canvas, Options options)
        {
            this.canvas = canvas;
            random = new Random();
            this.options = options;
        }

        public Fish GenerateRandomFish()
        {
            if (random.Next(512) < options.spawnProd)
            {
                FStatus randomStatus = (FStatus)random.Next(2);
                FType randomType;
                int randZ = random.Next(100);
                if (random.Next(100) < options.fishChan)
                {
                    if (randZ < 40)
                        randomType = FType.Karp;
                    else if (randZ < 80)
                        randomType = FType.Sudak;
                    else if (randZ < 90)
                        randomType = FType.Som;
                    else
                        randomType = FType.Dinamite;
                }
                else
                {
                    if (randZ < 47)
                        randomType = FType.Trash1;
                    else if (randZ < 94)
                        randomType = FType.Trash2;
                    else
                        randomType = FType.Sus;
                }
                int level = random.Next(5);            
                int randY = random.Next(100);

                Fish newFish = new Fish(randomStatus,  
                                        randomType, 
                                        level * 100 + randY,   
                                        2 + level / 2 + random.Next(3), 
                                        Ribis[randomType] + randY - 50);

                AddFishToCanvas(newFish);

                return newFish;
            }
            return null;
        }

        private void AddFishToCanvas(Fish fish)
        {

            Image fishImage = new Image
            {
                Width = fish.Width,
                Height = fish.Height
            };

            Canvas.SetLeft(fishImage, fish.X);
            Canvas.SetTop(fishImage, fish.Y);
            fish.SetImage(fishImage);
            if (fish.Status == FStatus.Right)
            {
                ScaleTransform flipHorizontal = new ScaleTransform(-1, 1);
                fish.MyImage.RenderTransform = flipHorizontal; 
            }
            canvas.Children.Add(fishImage);
        }
    }

    //Состояние Главной игры
    internal class GameState
    {
        //Настройки, очки и т.д.
        private Options myOptions;
        public int Score { get; set; }
        public GStatus status;
        //Рыбы
        public Fish CatchedFish = null;
        FishGenerator fishGenerator;
        List<Fish> fishes = null;

        //Крюк
        Hook hook;
        Image myRope;
        Canvas canvas;

        public GameState(Options myOptions, Canvas RiverCanvas, Image hook, Image rope)
        {
            status = GStatus.Go;
            this.hook = new Hook(hook) { X = 100, Y = 203 };
            this.hook.Speed = 2;
            fishGenerator = new FishGenerator(RiverCanvas, myOptions);

            Score = 0;
            this.myOptions = myOptions;
            canvas = RiverCanvas;
            myRope = rope;

            fishes = new List<Fish>();
            GenerateNewFish();
        }

        //Добавление рыбов в реку
        public void GenerateNewFish()
        {
            Fish fish = fishGenerator.GenerateRandomFish();
            if (fish != null)
                fishes.Add(fish);
        }

        //Движение в реке и всё что с этим связанно 
        public void MoveAll()
        {
            foreach (var fish in fishes)
            {
                if (fish.Move(hook.Y, hook.Eaten) && !hook.Eaten)
                {
                    CatchedFish = fish;
                    CatchedFish.Deliver += WeDiliveredIt;
                    hook.MakeHooked();
                }
            }
            for (int i = 0; i < fishes.Count; i++)
            {
                if (fishes[i].Status == FStatus.GoAway)
                {
                    canvas.Children.Remove(fishes[i].MyImage);
                    fishes.Remove(fishes[i]);
                }
            }
        }
        //Доставили что надо, куда надо
        public void WeDiliveredIt(int points)
        {
            ScoreUp(Score += points);
            fishes.Remove(CatchedFish);
            canvas.Children.Remove(CatchedFish.MyImage);
            CatchedFish = null;
            hook.Hooked = false;
        }

        //Движение 
        public void MovePlayer(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W) && (hook.Y - hook.Speed > 80))
            {
                if (hook.Eaten && !hook.Hooked && hook.Y < 120 ) hook.ChangeStat();
                hook.Y -= hook.Speed;
                Canvas.SetTop(hook.MyImage, hook.Y);
                myRope.Height = Canvas.GetTop(hook.MyImage) - 59;
                if (CatchedFish != null) CatchedFish.MoveY(hook.Y);
            }
            if (Keyboard.IsKeyDown(Key.S) && (hook.Y - hook.Speed < 555))
            {
                hook.Y += hook.Speed;
                Canvas.SetTop(hook.MyImage, hook.Y);
                myRope.Height = Canvas.GetTop(hook.MyImage) - 59;
                if (CatchedFish != null) CatchedFish.MoveY(hook.Y);
            }   
        }

        public delegate void Handler(int alpha);
        public event Handler ScoreUp;
    }
}
