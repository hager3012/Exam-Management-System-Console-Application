using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Final_Exam : Exam
    {

        public static int Grade { get; set; }
        public static List<string> ListOfAns { get; set; }
        public static int Total { get; set; }


        public Final_Exam()
        {
            SubjectOfExam = new Subject();
            SubjectOfExam.Question = new Question_List();
            SubjectOfExam.answers = new Answers();
            ListOfAns = new List<string>();
        }


        public static void ChooseTypeQ(int Num)
        {
            TF_Questions tF_Questions = new TF_Questions();
            MCQ_Questions mCQ_Questions = new MCQ_Questions();
            Console.Clear();
            int Type;
            bool flag;
            do
            {
                Console.Write($"Please Chooes The Type of Question Number {Num + 1} ( 1 For True OR False || 2 For MCQ) : ");
                flag = int.TryParse(Console.ReadLine(), out Type);
            } while ((!flag) || (Type != 1 && Type != 2));

            if (Type == 1)
            {

                Console.Clear();
                Console.WriteLine(tF_Questions);
                SubjectOfExam.Question.Add(tF_Questions.AddQuestion(Num + 1));

            }
            if (Type == 2)
            {

                Console.Clear();
                Console.WriteLine(mCQ_Questions);
                SubjectOfExam.Question.Add(mCQ_Questions.AddQuestion(Num + 1));
            }


        }
        public override void ShowExam()
        {

            int Ans;
            TimeSpan time;
            Stopwatch sw = Stopwatch.StartNew();
            Console.Clear();
            Console.WriteLine("Do You Want To  Start The Exam ( y For Yes | n For NO)");
            if (Char.Parse(Console.ReadLine()) == 'y')
            {
                Console.Clear();
                GetTotalQ();
                sw.Start();
                foreach (var item in SubjectOfExam.Question.list)
                {
                    Console.Clear();
                    Console.WriteLine($"{item.Header_Question}          Mark( {item.Mark} )");
                    Console.WriteLine(item.Body_Question);
                    foreach (var item1 in item.Answers)
                    {
                        Console.Write($"{item1.AnswerId} {item1.AnswerText}              ");

                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("--------------------------------------------------");
                    bool flag;
                    do
                    {
                        Console.Write("Please Enter The Answer :");
                        flag = int.TryParse(Console.ReadLine(), out Ans);
                    } while (!flag);
                    ListOfAns.Add(item.Answers[Ans - 1].AnswerText);
                    if (Ans == item.CorrectAns)
                    {
                        Grade += item.Mark;
                    }
                    time = TimeSpan.FromMinutes(sw.Elapsed.Minutes);
                    if (this.CompareTime(time) == 1)
                    {
                        break;
                    }
                }
                ShowAnswer();
                Console.WriteLine($"Your Exam Grade is {Grade} From {Total}");
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed.ToString()}");
            }
        }

        public  override  int CompareTime(TimeSpan time)
        {
            if (TimeExam.CompareTo(time) == -1)
            {
                Console.WriteLine("The exam has already Finished.");
                return 1;
            }
            return 0;
        }

        public static void GetTotalQ()
        {
            foreach (var item in SubjectOfExam.Question.list)
            {
                Total += item.Mark;
            }
        }

        public override void ShowAnswer()
        {
            Console.Clear();
            Console.WriteLine("Your Answers");
            int i = 0;
            foreach (var item in SubjectOfExam?.Question?.list)
            {
                Console.WriteLine($"Q{i + 1}    {item.Body_Question} : {ListOfAns[i]}");
                i++;
            }
        }


    }
}
