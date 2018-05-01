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

namespace WpfAppColorShemeForUser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        string users = null;
        List<Theme> ListUsers;
        public MainWindow()
        {
            InitializeComponent();
            ListUsers = new List<Theme>();
            Theme Petya = new Theme("Petya", "Aqua", 10);
            ListUsers.Add(Petya);
            Theme Vasya = new Theme("Vasya", "GreenYellow", 12);
            ListUsers.Add(Vasya);
            Theme Genya = new Theme("Genya", "Azure", 8);
            ListUsers.Add(Genya);
            for (int i = 0; i < ListUsers.Count; i++)
            {
                users += " " + ListUsers[i].Name;
            }
            lblListUsers.Content = users;
        }

        private void btnInputUser_Click(object sender, RoutedEventArgs e)
        {
            if (txbUser.Text.Length == 0)
                MessageBox.Show("Вы не авторизировались!", "Внимание");
            if (txbUser.Text.Length != 0)
            {
                for (int i = 0; i < ListUsers.Count; i++)
                {
                    if (txbUser.Text == ListUsers[i].Name)
                    {
                        var txbEditor = new TextBox();
                        grid.Children.Clear();
                        grid.Children.Add(txbEditor);
                        Grid.SetColumnSpan(txbEditor, 3);
                        Grid.SetRowSpan(txbEditor, 6);
                        txbEditor.AcceptsReturn = true;
                        txbEditor.AcceptsTab = true;
                        txbEditor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                        txbEditor.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                        txbEditor.Background = Brushes.Aqua;
                        //txbEditor.Background = ListUsers[i].BorderColor;
                        txbEditor.FontSize = ListUsers[i].FontSize;
                        
                    }
                }
            }
        }

        //Theme Petya = new Theme("Aqua", 10);
        //Theme Vasya = new Theme("GreenYellow", 10);
        //Theme Genya = new Theme("Azure", 10);




    }

    public class Theme
    {
        public string Name { get; set; } = null;
        public string BorderColor { get; set; } = null;
        public int FontSize { get; set; } = 0;

        public Theme()
        {
        }

        public Theme(string name, string color, int size)
        {
            Name = name;
            BorderColor = color;
            FontSize = size;
        }
    }
}
