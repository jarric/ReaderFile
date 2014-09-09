using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace ReaderFile
{
    /// <summary>
    /// ChooseTemp.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseTemp : UserControl
    {
        List<Question> list = new List<Question>();
        public ChooseTemp()
        {
            InitializeComponent();
        }
        public void HandleTxt(string filename)
        {
            int i = 0;
            string path = Directory.GetCurrentDirectory() + "\\Answer\\"+filename;


            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Question item = new Question();
            while (str != null)
            {
                if (str != "")
                {
                    if (i == 0)
                    {
                        item = new Question();
                        item.Header = str;
                    }
                    else if (i == 1)
                    {
                        item.AnswerA = str;
                    }
                    else if (i == 2)
                    {
                        item.AnswerB = str;
                    }
                    else if (i == 3)
                    {
                        item.AnswerC = str;
                    }
                    else if (i == 4)
                    {
                        item.AnswerD = str;
                        list.Add(item);
                    }
                    i++;
                    if (i == 5)
                    {
                        i = 0;
                    }
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            myListBox.ItemsSource = list;
            myListBox2.ItemsSource = list;
        }

        public void ChangeAnswerHidden()
        {
            myListBox.Visibility = Visibility.Hidden;
            myListBox2.Visibility = Visibility.Visible;
        }
    }
}
