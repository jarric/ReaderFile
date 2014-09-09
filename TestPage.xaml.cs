/********
 * author:SHL
 * editor:JSQ
 * 
 * 
 * ****/
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace ReaderFile
{
    /// <summary>
    /// TestPage.xaml 的交互逻辑
    /// </summary>
    public partial class TestPage : Window
    {
        //定义一个计数器，用来计算
        private int NEXTCOUNT = 1;
        //定义一个索引，用来标注当前取到list中的第几个
        private int curNum = 0;
        DispatcherTimer dispatcher;
        int count = 0;
        public TestPage()
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
            UserHelp.GetRanList();
            LoadPage();
        }
        /// <summary>
        /// 第一次加载
        /// </summary>
        private void LoadPage()
        {
            ANumber.Content = "1";
            if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
            {
                var article = GetArticleName();
                selectList.Children.Add(article);
            }
            else
            {
                var question = GetQuestionName();
                selectList.Children.Add(question);
            }
        }

        /// <summary>
        /// 根据索引获取问题
        /// </summary>
        /// <returns></returns>
        private UserControl GetQuestionName()
        {
            myStack.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            MyTime.Content = 0;
            if (dispatcher != null)
            {
                dispatcher.Stop();
                dispatcher = null;
            }
            ChooseTemp temp = new ChooseTemp();
            int curIndex = UserHelp.ranList[curNum];
            temp.HandleTxt("question"+curIndex+".txt");

            if (UserHelp.CurrentLevel == "2" || UserHelp.CurrentLevel == "4")
            {
                if (NEXTCOUNT % 3 == 1)
                {
                    temp.ChangeAnswerHidden();
                }
            }
            return temp;
        }

        /// <summary>
        /// 根据索引获取文章
        /// </summary>
        /// <returns></returns>
        private UserControl GetArticleName()
        {
            //var temp=new UserControl();
            CreateTimer();

            int curIndex = UserHelp.ranList[curNum];
            switch (curIndex)
            {
                case 1:
                    article2 temp2 = new article2();
                    if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                    {
                        temp2.ChangeMouse();
                    }
                    return temp2;
                case 2:
                    article3 temp3 = new article3();
                    if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                    {
                        temp3.ChangeMouse();
                    }
                    return temp3;
                case 3:
                    article4 temp4 = new article4();
                    if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                    {
                        temp4.ChangeMouse();
                    }
                    return temp4;
                case 4:
                    article5 temp5 = new article5();
                    if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                    {
                        temp5.ChangeMouse();
                    }
                    return temp5;
                case 5:
                    article6 temp6 = new article6();
                    if (UserHelp.CurrentLevel == "3" || UserHelp.CurrentLevel == "4")
                    {
                        temp6.ChangeMouse();
                    }
                    return temp6;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 获取索引
        /// </summary>
        private void GetIndex()
        {
            if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
            {
                if (NEXTCOUNT % 2 == 0)
                {
                    curNum = NEXTCOUNT / 2 - 1;
                }
                else
                {
                    curNum = NEXTCOUNT / 2;
                }
            }
            else
            {
                if (NEXTCOUNT % 3 == 0)
                {
                    curNum = NEXTCOUNT / 3 - 1;
                }
                else
                {
                    curNum = NEXTCOUNT / 3;
                }
            }
            ANumber.Content = curNum+1;
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NextStep();
        }
        /// <summary>
        /// 下一步具体操作
        /// </summary>
        private void NextStep()
        {
            selectList.Children.Clear();
            NEXTCOUNT++;
            GetIndex();
            if (UserHelp.CurrentLevel == "1" || UserHelp.CurrentLevel == "3")
            {
                if (NEXTCOUNT % 2 == 1)
                {
                    selectList.Children.Add(GetArticleName());
                }
                else
                {
                    selectList.Children.Add(GetQuestionName());
                }
                if (NEXTCOUNT == 10)
                {
                    next.Visibility = Visibility.Hidden;
                    submit.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (NEXTCOUNT % 3 == 0 || NEXTCOUNT % 3 == 1)
                {
                    selectList.Children.Add(GetQuestionName());
                }
                else
                {
                    selectList.Children.Add(GetArticleName());
                }
                if (NEXTCOUNT == 15)
                {
                    next.Visibility = Visibility.Hidden;
                    submit.Visibility = Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// 开始计时器
        /// </summary>
        private void CreateTimer()
        {
            myStack.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Hidden;
            count = UserHelp.StaticTime;
            CreateTimerdispatcherTimer();
        }
        /// <summary>
        /// 计时器程序
        /// </summary>
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
        private delegate void ChangeThreadCall();
        private void ChangeTime()
        {
            MyTime.Content = count;

            if (count == 0)
            {
                NextStep();
            }
            count--;
        }
        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new Result();
            window.Show();
            this.Close();
        }
    }
}
