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

        private int[,] mappa = new int[,]               
           {
               { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
               { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },                //0 vuol dire che è libero e pacman piò andare
               { 1, 0, 1, 1, 0, 1, 1, 0, 0, 1 },                //1 vuol dire che c'è un muro
               { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
               { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
           };
         private int casellaSize = 40;  //questo indica che ogni casella è 40x40 pixel

        private DispatcherTimer gameTimer = new DispatcherTimer();
        private int dirX = 0;
        private int dirY = 0;

        private int vite = 0;

        public MainWindow()
        {
            InitializeComponent();
           // DisegnaMappa();

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

        public void DisegnaMappa()
        {
            for (int r = 0; r < mappa.GetLength(0); r++)       // mappa.GetLength(0) serve nelle matrici ad ottenere il numero delle righe
            {
                for (int c = 0; c < mappa.GetLength(1); c++)       // mappa.GetLength(0) serve nelle matrici ad ottenere il numero delle colonne
                {
                    if (mappa[r,c] == 1)
                    {
                        Rectangle muro = new Rectangle();
                        muro.Width = casellaSize;            // sto impostando la larghezza del muro 
                        muro.Height = casellaSize;           // sto impostando l'altezza del muro, combinate farebbe un muro 40x40, come una casella
                        muro.Fill = Brushes.Blue;           // colore del muro

                        Canvas.SetLeft(muro, c * casellaSize);
                        Canvas.SetTop(muro, r * casellaSize);

                        gameCanvas.Children.Add(muro);
                    }
                }
            }
        }

    }
}