using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ReaderFile
{
    /// <summary>
    /// Read.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class Read : Window
    {
        DispatcherTimer dispatcher;
        int count = 0;

        /// <summary>
        /// JSQ
        /// </summary>
        //定义一个计数器，用来计算
        private int NEXTCOUNT = 1;

        public Read()
        {
            InitializeComponent();
            // 设置全屏
            this.WindowState = System.Windows.WindowState.Normal;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
            this.Topmost = true;

            this.Left = 0.0;
            this.Top = 0.0;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ReadData("start");
        }

        /// <summary>
        /// 读取开头
        /// </summary>
        /// <param name="type"></param>
        public void ReadData(string type)
        {
            myCanvas.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
            start.Children.Clear();
            int i = 1;
            string filename = "";

            if (type.Equals("start"))
            {
                filename = "level" + UserHelp.CurrentLevel + ".txt";
            }
            else if (type.Equals("end"))
            {
                filename = "End.txt";
            }
            string path = Directory.GetCurrentDirectory() + "\\StartFonts\\" + filename;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                TextBlock text = new TextBlock();
                text.FontFamily = new System.Windows.Media.FontFamily("宋体");
                text.FontSize = 20;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.HorizontalAlignment = HorizontalAlignment.Left;
                text.Text = str;
                Canvas.SetLeft(text, 40);
                Canvas.SetTop(text, 40 * i);
                start.Children.Add(text);
                str = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs.Close();
        }

        /// <summary>
        /// JSQ,改进了下一步
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Hidden;
            myCanvas.Visibility = Visibility.Visible;
            if (NEXTCOUNT == 1)
            {
                myButton.Visibility = Visibility.Hidden;
                LoadDocumentorQuestions();
                NEXTCOUNT++;
            }
            else if (NEXTCOUNT == 2)
            {
                if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
                {
                    CreateQuestionPath();
                    NEXTCOUNT++;
                }
                else
                {
                    CreateArticlePath();
                    NEXTCOUNT++;
                }
                UserHelp.FirstTime = MyTime.Content.ToString();
            }
            else if (NEXTCOUNT == 3)
            {
                myButton.Visibility = Visibility.Visible;
                if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
                {
                    CreateEndPath();
                    myButtonStack.Visibility = Visibility.Visible;
                    NEXTCOUNT = 1;
                    myButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    CreateQuestionPath();
                    NEXTCOUNT++;
                }
            }
            else
            {
                myButton.Visibility = Visibility.Hidden;
                myButtonStack.Visibility = Visibility.Visible;
                CreateEndPath();
                NEXTCOUNT = 1;
            }
        }

        private void LoadDocumentorQuestions()
        {
            myCanvas.Visibility = Visibility.Visible;
            start.Visibility = Visibility.Hidden;

            if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
            {
                count = UserHelp.StaticTime ;
                myStack.Visibility = Visibility.Visible;
                CreateTimerdispatcherTimer();
                CreateArticlePath();
            }
            else
            {
                myStack.Visibility = Visibility.Hidden;
                myButton.Visibility = Visibility.Visible;
                GetArticles("experimentQuestions.txt", "Answer", "firstQuestion");
            }
        }
        private void CreateQuestionPath()
        {
            myButton.Visibility = Visibility.Visible;
            myStack.Visibility = Visibility.Hidden;
            myCanvas.Children.Clear();
            string filename = "experimentQuestions.txt";
            GetArticles(filename, "Answer", "answer");
        }
        private void CreateArticlePath()
        {
            myStack.Visibility = Visibility.Visible;
            myButton.Visibility = Visibility.Hidden;
            count = UserHelp.StaticTime;
            CreateTimerdispatcherTimer();
            myCanvas.Children.Clear();
            string filename = "experimentArticle.txt";
            GetArticles(filename, "Article", "article");
        }

        private void CreateEndPath()
        {
            start.Children.Clear();
            ReadData("end");
        }
        private delegate void ChangeThreadCall();
        private void ChangeTime()
        {
            MyTime.Content = count;

            if (count == 0)
            {
                if (NEXTCOUNT == 1)
                {
                    myButton.Visibility = Visibility.Hidden;
                    LoadDocumentorQuestions();
                    NEXTCOUNT++;
                }
                else if (NEXTCOUNT == 2)
                {
                    if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
                    {
                        CreateQuestionPath();
                        NEXTCOUNT++;
                    }
                    else
                    {
                        CreateArticlePath();
                        NEXTCOUNT++;
                    }
                    UserHelp.FirstTime = MyTime.Content.ToString();
                }
                else if (NEXTCOUNT == 3)
                {
                    myButton.Visibility = Visibility.Visible;
                    if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
                    {
                        CreateEndPath();
                        myButtonStack.Visibility = Visibility.Visible;
                        NEXTCOUNT = 1;
                        myButton.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        CreateQuestionPath();
                        NEXTCOUNT++;
                    }
                }
                else
                {
                    myButton.Visibility = Visibility.Hidden;
                    myButtonStack.Visibility = Visibility.Visible;
                    CreateEndPath();
                    NEXTCOUNT = 1;
                }
            }
            count--;
        }
        private void CreateTimerdispatcherTimer()
        {
            if (dispatcher != null)
            {
                dispatcher.Stop();
                dispatcher = null;
            }
            dispatcher = new DispatcherTimer();
            dispatcher.Tick += new EventHandler(Handle);
            dispatcher.Interval = TimeSpan.FromSeconds(1);
            dispatcher.Start();
        }

        private void Handle(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new ChangeThreadCall(ChangeTime));
        }

        #region

        /// <summary>
        /// JSQ，增加一个参数区分，article，question，end
        /// </summary>
        public void GetArticles(string FileileName, string folder, string type)
        {
            myCanvas.Children.Clear();
            if (type == "article")
            {

                article1 article = new article1();
                if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                {
                    article.ChangeMouse();
                }
                myCanvas.Children.Add(article);
            }
            else
            {
                ChooseTemp temp = new ChooseTemp();
                temp.HandleTxt("experimentQuestions.txt");
                if (NEXTCOUNT == 1)
                {
                    temp.ChangeAnswerHidden();
                }
                myCanvas.Children.Add(temp);
            }
        }
        #endregion

        private void BackTest_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new Read();
            win.Show();
            this.Close();
        }

        private void ContinueTest_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new TestPage();
            win.Show();
            this.Close();
        }
    }
}