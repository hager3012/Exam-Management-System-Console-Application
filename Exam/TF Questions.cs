using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class TF_Questions : Base_Question
    {
        public List<Answers> Ans;
        public override string ToString()
        {
            return $"True | False Question";
        }
        public void ShowAns()
        {
            foreach (var item in Answers)
            {
                Console.WriteLine(item.AnswerText);
            }
        }

        public Base_Question AddQuestion(int Num)
        {
            Header_Question = $"True | False Question {Num}";
            Console.WriteLine("Please Enter The Body Of Question");
            Body_Question = Console.ReadLine();
            int mark;
            bool flag;
            do
            {
                Console.WriteLine("Please Enter The Marks Of Question");
                flag = int.TryParse(Console.ReadLine(), out mark);
            } while (!flag);
            Mark = mark;
            Answers = new List<Answers>();
            Answers.Add(new Answers() { AnswerId = 1, AnswerText = "False" });
            Answers.Add(new Answers() { AnswerId = 2, AnswerText = "True" });

            int Type;
            bool flagCor;
            do
            {
                Console.WriteLine($"Please Enter The Right Answer Of Question {Num} ( 1 For False | 2 For True)");
                flagCor = int.TryParse(Console.ReadLine(), out Type);
            } while ((!flagCor) || (Type != 1 && Type != 2));
            CorrectAns = Type;
            return this;
        }
    }
}
