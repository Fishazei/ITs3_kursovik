using System.Windows;

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuPage menuPage = null;

        public MainWindow()
        {
            InitializeComponent();
            menuPage = new MenuPage();

            MainFrame.Content = menuPage;
        }
    }
}