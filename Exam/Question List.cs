using Exam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
     class Question_List
    {
        public List<Base_Question> list;
        public Question_List()
        {
            list = new List<Base_Question>();
        }

        public void Add(Base_Question question)
        {
            list.Add(question);
        }

    }
}
