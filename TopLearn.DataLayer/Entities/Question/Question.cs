using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TopLearn.DataLayer.Entities.Question
{
   public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int UserId { get; set; }
        
        [Display(Name = "عنوان سوال")]
        [Required(ErrorMessage = "عنوان سوال را وارد کنید")]
        [MaxLength(400)]
        public string Title { get; set; }
        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "متن سوال را وارد کنید")]
        public string Body { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public User.User User { get; set; }
        public Course.Course Course { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
