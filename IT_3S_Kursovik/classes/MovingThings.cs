using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace IT_3S_Kursovik.classes
{
    internal abstract class MovingObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Speed { get; set; }
        protected Image myImage;
        public Image MyImage { get { return myImage; } }
        protected ImageSource texture = null;
        public double Width { get; set; }
        public double Height { get; set; }

        public void SetImage(Image image)
        {
            myImage = image;
            myImage.Source = texture;
        }

    }
    internal class Hook : MovingObject
    {
        private ImageSource textureEmpty = null;
        bool eaten = false;
        public bool Eaten { get { return eaten; } }
        public bool Hooked { get; set; }
        public Hook(Image image)
        {
            Hooked = false;
            myImage = image;
            Width = 52;
            Height = 82;
            texture = new BitmapImage(new Uri("assets/hook.png", UriKind.RelativeOrAbsolute));
            textureEmpty = new BitmapImage(new Uri("assets/hook-empty.png", UriKind.RelativeOrAbsolute));
        }
        public void MakeHooked()
        {
            Hooked = !Hooked;
            ChangeStat();
        }
        public void ChangeStat()
        {
            eaten = !eaten;
            myImage.Source = eaten? textureEmpty : texture;
        }
    }
    internal class Fish : MovingObject
    {
        //Смещение при поимке относительно поплавка
        public double Xs { get; set; } 
        public double Ys { get; set; } 
        
        //Информация о рыбе
        FType type;
        FStatus status;
        public FStatus Status { get { return status; } }
        public int points;
        static readonly Dictionary<FType, int> Widthes = new()
        {
            {FType.Som ,     148 },
            {FType.Karp ,    135 },
            {FType.Sudak,    180 },
            {FType.Dinamite, 100 },
            {FType.Sus ,     100 },
            {FType.Trash1 ,  101 },
            {FType.Trash2 ,  140 }
        };

        public Fish(FStatus fStatus, FType fType, double y, int speed, int points)
        {
            Y = y;
            status = fStatus;
            switch (Status)
            {
                case (FStatus.Left): X = 1200; break;
                case (FStatus.Right): X = -100; break;
                default: X = -100; break;
            }
            type = fType;
            Speed = speed;
            this.points = points;

            Width = Widthes[type];
            Height = 100;

            texture = Images.GetImage(type);
        }
        public FType GetType()
        {
            return type;
        }
        public void ChangeStat(FStatus fstatus)
        {
            status = fstatus;
        }
        public bool Move(double Y, bool AHooked)
        {
            if (Status == FStatus.Caught) return false;
            if (Status == FStatus.Left)
            {
                X -= Speed / 2;
                Canvas.SetLeft(myImage, X);
                if (X < -200) status = FStatus.GoAway;
            }    
            if (Status == FStatus.Right)
            {
                X += Speed / 2;
                Canvas.SetLeft(myImage, X);
                if (X > 1400) status = FStatus.GoAway;
            }
            if (!AHooked)
            {
                if (CheckCatched(Y)) return true;
            }
            return false;
        }
        private bool CheckCatched(double Y)
        {
            if (Status == FStatus.Left || Status == FStatus.Right)
            {
                if (X > 590 && X < 610)
                    if (this.Y + 138 > Y && this.Y + 50 < Y) status = FStatus.Caught; 
            }
            if (Status == FStatus.Caught)
            {
                Ys = Math.Abs(Y - this.Y - 128); 
                return true;
            }
            return false;
        }
        public bool MoveY(double Y)
        {
            this.Y = Y - 128 + Ys;
            Canvas.SetTop(myImage, this.Y);
            if (this.Y < 35)
            { 
                status = FStatus.Delivered;
                Deliver(points);
                return true;
            }
            return false;
        }

        //Событие доставки рыбы на сушу
        public delegate void Handler(int alpha);
        public event Handler Deliver;

    }
    //Облако утреннего тумана
    internal class Fog : MovingObject
    {

        public Fog(double x, double y, int speed) 
        {
            X = x;
            Y = y;
            Speed = speed;
            texture = new BitmapImage(new Uri("assets/1.png", UriKind.RelativeOrAbsolute));
        }

        public void Move()
        {
            Random random = new Random();
            if (random.Next(100) == 1 || Y < 10 || Y > 500)
                Speed = -Speed;

            Y += (double)Speed / 2;
            Canvas.SetTop(myImage, Y);
        }
    }
}
