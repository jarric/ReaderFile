using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderFile
{
    public class Question
    {
        private string m_header;

        public string Header
        {
            get { return m_header; }
            set { m_header = value; }
        }
        private string m_answer;

        public string Answer
        {
            get { return m_answer; }
            set { m_answer = value; }
        }
        private string m_answerA;

        public string AnswerA
        {
            get { return m_answerA; }
            set { m_answerA = value; }
        }
        private string m_answerB;

        public string AnswerB
        {
            get { return m_answerB; }
            set { m_answerB = value; }
        }
        private string m_answerC;

        public string AnswerC
        {
            get { return m_answerC; }
            set { m_answerC = value; }
        }
        private string m_answerD;

        public string AnswerD
        {
            get { return m_answerD; }
            set { m_answerD = value; }
        }
    }
}
