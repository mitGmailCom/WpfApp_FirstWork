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
        private bool FlagUserExist { get; set; } = false;
        private string Users { get; set; } = null;
        private List<Theme> ListUsers;

        public MainWindow()
        {
            InitializeComponent();
            ListUsers = new List<Theme>();
            Theme Petya = new Theme("Petya", "Aqua", 16);
            ListUsers.Add(Petya);
            Theme Vasya = new Theme("Vasya", "GreenYellow", 12);
            ListUsers.Add(Vasya);
            Theme Genya = new Theme("Genya", "Coral", 8);
            ListUsers.Add(Genya);
            for (int i = 0; i < ListUsers.Count; i++)
            {
                Users += " " + ListUsers[i].Name;
            }
            lblListUsers.Content = Users;
        }

        private void btnInputUser_Click(object sender, RoutedEventArgs e)
        {
            Theme temp = new Theme();
            if (txbUser.Text.Length == 0)
                MessageBox.Show("Вы не авторизировались!", "Внимание");

            if (txbUser.Text.Length != 0)
            {
                for (int i = 0; i < ListUsers.Count; i++)
                {
                    if (txbUser.Text == ListUsers[i].Name)
                    {
                        FlagUserExist = true;
                        temp = ListUsers[i];
                        break;
                    }

                    if (txbUser.Text != ListUsers[i].Name)
                        FlagUserExist = false;

                }

                    if (FlagUserExist == false)
                    {
                        MessageBox.Show("Пользователя с таким именем не существует!", "Ошибка");
                        FlagUserExist = false;
                    }

                    if (FlagUserExist == true)
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
                        var color = (Color)ColorConverter.ConvertFromString(temp.Color);
                        txbEditor.Background = new SolidColorBrush(color);
                        txbEditor.FontSize = temp.FontSize;
                        FlagUserExist = false;
                    }
            }
        }
    }

    public class Theme
    {
        public string Name { get; set; } = null;
        public string Color { get; set; } = null;
        public int FontSize { get; set; } = 0;

        public Theme()
        { }

        public Theme(string name, string color, int size)
        {
            Name = name;
            Color = color;
            FontSize = size;
        }
    }
}
