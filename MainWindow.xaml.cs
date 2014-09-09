using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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

namespace ReaderFile
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserHelp.StaticTime = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            UserHelp.CurrentLevel = CurLevel.SelectionBoxItem.ToString();
            UserHelp.CurrentNum = TestNum.Text;
            Window window = new Read();
            window.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
