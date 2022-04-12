using System;
using System.Threading;
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

namespace SuperMario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool goright, goLeft, goUp, goDown;
        int playerspeed = 10;
        double gravety = 0;
        bool grounded;

        DispatcherTimer Gametimer = new DispatcherTimer();
        DispatcherTimer Gravetytimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Focus();
            Gametimer.Tick += Gametimerevent;
            Gametimer.Interval = TimeSpan.FromMilliseconds(20);
            Gametimer.Start();
            Gravetytimer.Tick += Gravetytimerevent;
            Gravetytimer.Interval = TimeSpan.FromMilliseconds(40);
            Gravetytimer.Start();
        }

        private void Gravetytimerevent(object sender, EventArgs e)
        {
            
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goright = true;
            }
            if (e.Key == Key.Up)
            {
                goUp = true;
            }
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goright = false;
            }
            if (e.Key == Key.Up)
            {
                goUp = false;
            }
            if (e.Key == Key.Down)
            {
                goDown = false;
            }
        }

        private void Gametimerevent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(player) > 5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerspeed);
            }

            if(goright == true && Canvas.GetLeft(player) + (player.Width + 20) < Application.Current.MainWindow.Width )
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerspeed);
            }

            if (goUp == true && Canvas.GetTop(player) > 5)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - playerspeed);
            }

            /*if (goDown == true && Canvas.GetTop(player) + (player.Height + 40) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + playerspeed);
            }*/
            if (grounded == false && Canvas.GetTop(player) + (player.Height + 40) < Application.Current.MainWindow.Height)
            {
                gravety += 0.3;
                Canvas.SetTop(player, Canvas.GetTop(player) + gravety);
            }
            else
            {
                gravety = 0;
            }
        }
    }
}
