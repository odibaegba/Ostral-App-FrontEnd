using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Responses
{
    public class CourseListResponse
    {
        public IEnumerable<CourseListItem> Courses { get; set; }
    }
    public class CourseListItem
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string TutorFullName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Duration { get; set; }
        public string ImageUrl { get; set; }
    }
}
