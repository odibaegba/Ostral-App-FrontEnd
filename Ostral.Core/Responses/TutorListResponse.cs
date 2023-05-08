using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Responses
{
    public class TutorListResponse
    {
        public IEnumerable<TutorListItem> Tutors { get; set; }
    }
    
    public class TutorListItem
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
    }
}
