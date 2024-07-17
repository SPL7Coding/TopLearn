using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.DTOs.Course
{
    public class ShowCourseListItemViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Price { get; set; }
        public List<CourseEpisode> CourseEpisodes { get; set; }
    }
}
