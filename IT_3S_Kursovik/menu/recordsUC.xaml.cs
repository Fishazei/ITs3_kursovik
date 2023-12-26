using System.Windows;
using System.Windows.Controls;

namespace IT_3S_Kursovik.menu
{
    /// <summary>
    /// Логика взаимодействия для UC с рекордами
    /// </summary>
    public partial class recordsUC : UserControl
    {
        public recordsUC()
        {
            InitializeComponent();
        }

        public string Records
        {
            get { return Topper.Text; }
            set { Topper.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;

            Closed?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Closed;
    }
}
