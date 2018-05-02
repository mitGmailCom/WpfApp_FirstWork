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

namespace WpfAppRunningStatic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Marge { get; set; } = 10;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point m = e.GetPosition(btnCatch);
            double l = Canvas.GetLeft(btnCatch);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            Point m = e.GetPosition(wind);
            Title = m.ToString();
            double l = Canvas.GetLeft(btnCatch);
            double r = l + btnCatch.Width;
            double t = Canvas.GetTop(btnCatch);
            double b = t+btnCatch.Height;

            //Left
            if (m.X >= l - Marge & m.X < l & m.Y >= t & m.Y <= b)
                Canvas.SetLeft(btnCatch, rnd.Next((int)(wind.Width - btnCatch.Width)));
            
            //Right
            if (m.X > r & m.X <= r + Marge & m.Y >= t & m.Y <= b)
                Canvas.SetLeft(btnCatch, rnd.Next((int)(wind.Width - btnCatch.Width)));
           
            //Top
            if (m.X >= l & m.X <= r & m.Y >= t - Marge & m.Y < t)
                Canvas.SetTop(btnCatch, rnd.Next((int)(wind.Height - btnCatch.Height)));
            
            //Bottom
            if (m.X >= l & m.X <= r & m.Y > b & m.Y <= b + Marge)
                Canvas.SetTop(btnCatch, rnd.Next((int)(wind.Height - btnCatch.Height)));
        }
    }
}
