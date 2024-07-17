using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.Question;
using TopLearn.DataLayer.Entities.Question;

namespace TopLearn.Core.Services.Interfaces
{
   public interface IForumService
    {
        #region Question

        int AddQuestion(Question question);

        ShowQuestionVM ShowQuestion(int questionId);

        IEnumerable<Question> GetQuestions(int? courseId, string filter = "");

        #endregion

        #region Answer

        void AddAnswer(Answer answer);
        void ChangeIsTrueAnswer(int questionId, int answerId);

        #endregion
    }
}
