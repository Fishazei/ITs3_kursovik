using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IT_3S_Kursovik.classes
{
    /// <summary>
    /// Класс, предназначенный для обработки логики поплавка и лески на глобально карте
    /// </summary>
    class HookMap
    {
        double x0, y0;
        public double xcur, ycur;
        double l, m;
        double force;

        public Line FLine { get; set; }
        public Rectangle MyRectangle { get; set; }
        Canvas myCanvas;

        public HookMap(double mouseTop, double mouseLeft, double currentTop, double currentLeft, Canvas canvas, TimeSpan heldTime)
        {
            myCanvas = canvas;
            y0 = currentLeft + 50;
            x0 = currentTop + 50;

            l = mouseTop - 10 - x0;
            m = mouseLeft - 10 - y0;

            //Задание крючка
            MyRectangle = new Rectangle();

            MyRectangle.Height = 20;
            MyRectangle.Width = 20;
            MyRectangle.Fill = new SolidColorBrush(Colors.IndianRed);
            Canvas.SetTop(MyRectangle, y0 - 10);
            Canvas.SetLeft(MyRectangle, x0 - 10);

            //Задание лески
            FLine = new Line();
            FLine.X1 = x0;
            FLine.Y1 = y0;
            FLine.X2 = x0;
            FLine.Y2 = y0;
            FLine.StrokeThickness = 4;
            FLine.Stroke = new SolidColorBrush(Colors.AliceBlue);

            myCanvas.Children.Add(MyRectangle);
            myCanvas.Children.Add(FLine);
            // Вычисление силы вылета в зависимости от времени зажатия
            force = Math.Min(100, heldTime.TotalMilliseconds / 800);

            MakeUP();
        }

        public bool MakeUP()
        {
            double f = 0;
            while (f < force)
            {
                f += 0.001;
                xcur = l * f - 10 + x0;
                ycur = m * f - 10 + y0;

                Canvas.SetTop(MyRectangle, ycur);
                Canvas.SetLeft(MyRectangle, xcur);

                FLine.X2 = l * f + x0;
                FLine.Y2 = m * f + y0;
            }

            return true;
        }

        public void Move0(double currentTop, double currentLeft)
        {
            y0 = currentLeft + 50;
            x0 = currentTop + 50;

            FLine.X1 = x0;
            FLine.Y1 = y0;

            l = xcur - 10 - x0;
            m = ycur - 10 - y0;
        }

        public void GoBack()
        {
            xcur -= l * force * 0.01;
            ycur -= m * force * 0.01;

            FLine.X2 -= l * force * 0.01;
            FLine.Y2 -= m * force * 0.01;

            Canvas.SetTop(MyRectangle, ycur);
            Canvas.SetLeft(MyRectangle, xcur);

            CheckMePLS(xcur, ycur);
        }

        public void DeleteMePLS()
        {
            myCanvas.Children.Remove(MyRectangle);
            myCanvas.Children.Remove(FLine);
            myCanvas = null;

        }
        //Событие 
        public delegate void Handler(double xcur, double ycur);
        public event Handler CheckMePLS;
    }
}
