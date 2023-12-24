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

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Interaction logic for PauseUC.xaml
    /// </summary>
    public partial class PauseUC : UserControl
    {
        public PauseUC()
        {
            InitializeComponent();
        }

        public delegate void Handler();
        public event Handler GO;
        public event Handler END;

        //Выход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            END();
        }

        public void Visible(bool flood)
        {
            Visibility = flood ? Visibility.Visible : Visibility.Collapsed;
            Exit1.IsEnabled = flood;
            GO();
        }

        //Возобновить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            Exit1.IsEnabled = false;
        }
    }
}
