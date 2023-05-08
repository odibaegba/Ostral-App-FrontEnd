using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Requests
{
    public class CourseRequest
    {
        public string Name { get; set; } = string.Empty;
        public string TutorName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
    }
}
