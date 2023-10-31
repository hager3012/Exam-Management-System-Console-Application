using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    abstract class Exam
    {
        public static TimeSpan TimeExam { get; set; }
        public int NumberOfQuestion { get; set; }
        public static Subject SubjectOfExam { get; set; }
        public abstract void ShowExam();
        public abstract int CompareTime(TimeSpan time);
        public abstract void ShowAnswer();

        public void SetTimeAndNumberQ()
        {
            int OutTime;
            int Number;
            bool FlagTime;
            bool FlagNumber;
            do
            {
                Console.Write("Please Enter The Time Of Exam in Minutes : ");
                FlagTime = int.TryParse(Console.ReadLine(), out OutTime);
            } while (!FlagTime);
            TimeExam = TimeSpan.FromMinutes(OutTime);
            do
            {
                Console.Write("Please Enter The Number Of Questions You Wanted To Create : ");
                FlagNumber = int.TryParse(Console.ReadLine(), out Number);
            } while (!FlagNumber);
            NumberOfQuestion = Number;

        }
    }
}
