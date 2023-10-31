using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Interfaces
{
    internal interface IQuestion
    {
        public string Header_Question { get; set; }
        public string Body_Question { get; set; }
        public int Mark { get; set; }
    }
}
