using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Multiple_Choices : Base_Question
    {
        public Base_Question AddQuestion(int Num)
        {
            Header_Question = $"Multiple Question {Num}";
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
            Answers = new List<Answers>(4);

            string Text;
            Console.WriteLine("The Choices Of Questions : ");
            for (int i = 0; i < 4; i++)
            {

                Console.Write($"Please Enter The Choice Number {i + 1} : ");
                Text = Console.ReadLine();
                Answers.Add(new Answers() { AnswerId = i + 1, AnswerText = Text });
            }

            int NumberQ;
            bool flagQ;
            do
            {
                Console.Write("Please Enter  How many questions are correct out of four questions?");
                flagQ = int.TryParse(Console.ReadLine(), out NumberQ);
            } while ((!flagQ) || (NumberQ > 4));
            for (int i = 0; i < NumberQ; i++)
            {
                int Type;
                bool flagCor;
                do
                {
                    Console.WriteLine($"Please Specify The {i + 1}st Right Choise Of Question");
                    flagCor = int.TryParse(Console.ReadLine(), out Type);
                } while ((!flagCor) || (Type > 4));
                Choices.Add(Type - 1);
            }
            return this;
        }

        public override string ToString()
        {
            return $"MCQ  Question Multiple Choices";
        }
    }
}
