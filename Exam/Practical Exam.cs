using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Practical_Exam : Exam
    {


        public Practical_Exam()
        {
            SubjectOfExam = new Subject();
            SubjectOfExam.Question = new Question_List();
            SubjectOfExam.answers = new Answers();
        }


        public static void SetQuestions(int Num)
        {
            Multiple_Choices multiple_Choices = new Multiple_Choices();
            Console.Clear();
            Console.WriteLine(multiple_Choices);
            multiple_Choices.Choices = new List<int>();
            SubjectOfExam.Question.Add(multiple_Choices.AddQuestion(Num + 1));
        }
        public override void ShowExam()
        {
            TimeSpan time;
            Stopwatch sw = Stopwatch.StartNew();
            Console.Clear();
            Console.WriteLine("Do You Want To  Start The Exam ( y For Yes | n For NO)");
            if (Char.Parse(Console.ReadLine()) == 'y')
            {
                Console.Clear();
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

                    Console.Write("Please Enter The Answer Multiple Choices as (1,2,3,4):");
                    Console.ReadLine();

                    time = TimeSpan.FromMinutes(sw.Elapsed.Minutes);
                    if (CompareTime(time) == 1)
                    {
                        break;
                    }
                }
                ShowAnswer();
                Console.WriteLine("\n");
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed.ToString()}");
            }
        }
        public override int CompareTime(TimeSpan time)
        {
            if (TimeExam.CompareTo(time) == -1)
            {
                Console.WriteLine("The exam has already Finished.");
                return 1;
            }
            return 0;
        }
        public override void ShowAnswer()
        {
            Console.Clear();
            Console.WriteLine("Your Answers");
            int i = 0;
            int j = 0;
            foreach (var item in SubjectOfExam.Question.list)
            {
                Console.WriteLine($"Q{i + 1}    {item.Body_Question} : ");
                foreach (var item1 in item.Choices)
                {

                    Console.WriteLine($"Multiple Correct Answer {j + 1}: {item.Answers[item1].AnswerText}");
                    j++;
                }

                i++;
                j = 0;
                Console.WriteLine("\n");
            }
        }
    }
}
