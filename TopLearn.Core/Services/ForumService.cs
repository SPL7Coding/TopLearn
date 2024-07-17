using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.DTOs.Question;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Question;

namespace TopLearn.Core.Services
{
   public class ForumService:IForumService
   {
       private TopLearnContext _context;

       public ForumService(TopLearnContext context)
       {
           _context = context;
       }

        public int AddQuestion(Question question)
        {
            question.CreateDate=DateTime.Now;
            question.ModifiedDate=DateTime.Now;
            _context.Add(question);
            _context.SaveChanges();
            return question.QuestionId;
        }

        public ShowQuestionVM ShowQuestion(int questionId)
        {
            var question = new ShowQuestionVM();
            question.Question= _context.Questions.Include(q => q.User)
                .FirstOrDefault(q => q.QuestionId == questionId);
            question.Answers = _context.Answers.Where(a => a.QuestionId == questionId).Include(u=>u.User).ToList();
            return question;
        }

        public IEnumerable<Question> GetQuestions(int? courseId, string filter = "")
        {
            IQueryable<Question> result = _context.Questions
                .Where(q => EF.Functions.Like(q.Title, $"%{filter}%"));

            if (courseId != null)
            {
                result = result.Where(q => q.CourseId == courseId);
            }

            return result.Include(q=>q.Course)
                .Include(q=>q.User).ToList();
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public void ChangeIsTrueAnswer(int questionId, int answerId)
        {
            var answers = _context.Answers.Where(a => a.QuestionId == questionId);
            foreach (var ans in answers)
            {
                ans.IsTrue = false;

                if (ans.AnswerId == answerId)
                {
                    ans.IsTrue = true;
                }
            }
            _context.UpdateRange(answers);
            _context.SaveChanges();
        }
   }
}
