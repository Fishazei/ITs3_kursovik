using System.Windows;
using System.Windows.Controls;

namespace IT_3S_Kursovik
{
    /// <summary>
    /// Окно с выбором сложности игры
    /// </summary>
    public partial class DifficultyWindow : Window
    {
        public int Difficulty { get; set; } // Публичное свойство со сложностью, устанавливается непосредственно перед "игрой"
        private int difBuf;                 // "Буфер" сложности, обновляется при каждом нажатии какой нибудь RadioButton

        public DifficultyWindow()
        {
            InitializeComponent();
            Difficulty = 0;
            difBuf = 0;
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = difBuf;
            if (Difficulty != 0)
            {
                Close();
            }
        }
        // Вызывается при нажатии на какой нибудь RadioButton
        private void Difficulty_Check(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Name == "evening")
                difBuf = 1;
            else if (button.Name == "morning")
                difBuf = 2;
            else
                difBuf = 3;
        }
    }
}
