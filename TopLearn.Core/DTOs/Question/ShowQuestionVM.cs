using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.DataLayer.Entities.Question;

namespace TopLearn.Core.DTOs.Question
{
   public class ShowQuestionVM
    {
        public DataLayer.Entities.Question.Question Question { get; set; }
        public List<Answer> Answers { get; set; }


    }
}
