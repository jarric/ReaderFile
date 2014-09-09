/*
 * Copyright © SYIT. 2012, 2015. All Rights Reserved
 * Author: 孙海龙
 * Version: 1.0
 * Modification history:
 * 1. 2014/3/10 16:53:39 孙海龙 创建
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReaderFile
{
    public class UserHelp
    {
        /// <summary>
        /// 实验水平
        /// </summary>
        public static string CurrentLevel { get; set; }

        /// <summary>
        /// 被测编号
        /// </summary>
        public static string CurrentNum { get; set; }

        /// <summary>
        /// 答对题数
        /// </summary>
        public static int CorrectNum { get; set; }

        /// <summary>
        /// 答错题数
        /// </summary>
        public static int ErrorNum { get; set; }

        /// <summary>
        /// 第一阶段时间
        /// </summary>
        public static string FirstTime { get; set; }

        /// <summary>
        /// 答错题数
        /// </summary>
        public static string SecondTime { get; set; }

        /// <summary>
        /// 答错题数
        /// </summary>
        public static string ThirdTime { get; set; }

        /// <summary>
        /// 当前数字
        /// </summary>
        private static int m_question = 1;

        public static List<int> ranList = new List<int>();

        private static List<string> m_answerList = new List<string>();

        public static List<string> AnswerList
        {
            get { return UserHelp.m_answerList; }
            set { UserHelp.m_answerList = value; }
        }

        private static List<string> questionTime = new List<string>();

        public static List<string> QuestionTime
        {
            get { return UserHelp.questionTime; }
            set { UserHelp.questionTime = value; }
        }

        private static List<string> articleTime = new List<string>();

        public static List<string> ArticleTime
        {
            get { return UserHelp.articleTime; }
            set { UserHelp.articleTime = value; }
        }

        public static int ReadTime { get;set;}

        public static int AnswerTime { get; set; }

        public static int StaticTime { get; set; }

        /// <summary>
        ///  保存实验记录
        /// </summary>
        public static void SaveRecord()
        {
            string result = "";
            for (int i = 0; i < ranList.Count; i++)
            {
                result += ranList[i];
            }
            string path = Directory.GetCurrentDirectory() + "\\Record\\预实验数据.txt";
            StreamWriter SW;
            SW = File.AppendText(path);
            string appendTxt = UserHelp.CurrentNum + "  " + UserHelp.CurrentLevel + "  " +  result;
            SW.WriteLine(appendTxt);
            SW.Close();
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        public static void GetRanList()
        {
            Random fRandom = new Random();
            int fCurNum = 0;
            while (ranList.Count < 5)
            {
                fCurNum = fRandom.Next(1, 6);
                if (!ranList.Contains(fCurNum))
                    ranList.Add(fCurNum);
            }
        }
    }
}
