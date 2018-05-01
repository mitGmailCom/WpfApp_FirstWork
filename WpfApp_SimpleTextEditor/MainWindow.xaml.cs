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

namespace WpfApp_SimpleTextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string TempStr { get; set; } = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            if (txbSimpleEditor.Text.Length != 0)
            {
                if (txbSimpleEditor.SelectedText.Length != 0)
                    txbSimpleEditor.Cut();
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            if (txbSimpleEditor.Text.Length != 0)
            {
                if (txbSimpleEditor.SelectedText.Length != 0)
                    txbSimpleEditor.Copy();
            }
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            if(Clipboard.ContainsText())
                txbSimpleEditor.Paste();
            Clipboard.Clear();
        }
    }
}
