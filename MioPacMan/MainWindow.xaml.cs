using System.Reflection;
using System.Text;
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

namespace MioPacMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private int dirX = 0;
        private int dirY = 0;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

        }

        public void GameLoop(object sender, EventArgs e)
        {

            double x = Canvas.GetLeft(pacMan);
            double y = Canvas.GetTop(pacMan);

            x += dirX;
            y += dirY;

            Canvas.SetLeft(pacMan, x);
            Canvas.SetTop(pacMan, y);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double coordinateX = Canvas.GetLeft(pacMan);
            double coordinateY = Canvas.GetTop(pacMan);


            if (e.Key == Key.Left)
            {
                dirX = -10; // Si muove a sinistra di 10 pixel a ogni tic
                dirY = 0;   // Si ferma in verticale
            }

            if (e.Key == Key.Right)
            {

                dirX = +10; // Si muove a sinistra di 10 pixel a ogni tic
                dirY = 0;   // Si ferma in verticale

            }


            if (e.Key == Key.Up)
            {
                dirY = -10; // Si muove a sinistra di 10 pixel a ogni tic
                dirX = 0;
            }

            if (e.Key == Key.Down)
            {

                dirY = +10; // Si muove a sinistra di 10 pixel a ogni tic
                dirX = 0;

            }

        }
    }
}