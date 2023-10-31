using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Interfaces;

namespace Exam
{
     class Base_Question : IQuestion
    {
        public string Header_Question { get; set; }
        public string Body_Question { get; set; }

        public Exam exam { get; set; }
        public List<Answers> Answers { get; set; }
        public int CorrectAns { get; set; }
        public List<int> Choices { get; set; }
        public int Mark { get; set; }

    }
}
