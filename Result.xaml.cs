using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ReaderFile
{
    /// <summary>
    /// Result.xaml 的交互逻辑
    /// </summary>
    public partial class Result : Window
    {
        public Result()
        {
            InitializeComponent();
            UserHelp.SaveRecord();
            GetEnd("AllEnd.txt", "StartFonts");
        }

        private void GetEnd(string FileileName, string folder)
        {
            myCanvas.Children.Clear();
            StackPanel panel = new StackPanel();
            string path = Directory.GetCurrentDirectory() + "\\" + folder + "\\" + FileileName;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                TextBlock text = new TextBlock();
                text.LineHeight = 2;
                text.TextWrapping = TextWrapping.Wrap;
                text.Width = 600;
                text.FontFamily = new System.Windows.Media.FontFamily("宋体");
                text.FontSize = 20;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.HorizontalAlignment = HorizontalAlignment.Left;
                text.Text = str;
                panel.Children.Add(text);
                str = sr.ReadLine();
            }
            Canvas.SetLeft(panel, 70);
            Canvas.SetTop(panel, 50);
            myCanvas.Children.Add(panel);
            sr.Close();
            fs.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
