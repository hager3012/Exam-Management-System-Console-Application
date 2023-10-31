using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Subject
    {
        public int Subject_Id { get; set; }
        public string Subject_Name { get; set; }

        public static Exam Exam_Subject { get; set; }
        public Question_List Question { get; set; }
        public Answers answers { get; set; }
        public int CorrectAnswer { get; set; }
        public Subject(int Id, string Name)
        {
            Subject_Id = Id;
            Subject_Name = Name;
            Question = new Question_List();
            answers = new Answers();

        }
        public Subject()
        {

        }
        public void CreateExam()
        {

            int Type;
            bool Flag;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create ( 1 For Final OR 2 For Practical ) : ");
                Flag = int.TryParse(Console.ReadLine(), out Type);
            } while ((!Flag) || (Type != 1 && Type != 2));

            if (Type == 1)
            {
                CreateFinalExam();
            }
            if (Type == 2)
            {
                CreatePractical_Exam();
            }
        }
        public static void CreateFinalExam()
        {
            Exam_Subject = new Final_Exam();
            Exam_Subject.SetTimeAndNumberQ();
            int Count = 0;
            do
            {
                Final_Exam.ChooseTypeQ(Count);
                Count++;
            } while (Count.CompareTo(Exam_Subject.NumberOfQuestion) == -1);
            Exam_Subject.ShowExam();
        }
        public static void CreatePractical_Exam()
        {
            Exam_Subject = new Practical_Exam();
            Exam_Subject.SetTimeAndNumberQ();
            int Count = 0;
            do
            {
                Practical_Exam.SetQuestions(Count);
                Count++;
            } while (Count.CompareTo(Exam_Subject.NumberOfQuestion) == -1);
            Exam_Subject.ShowExam();
        }
    }
}
