using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Responses
{
    public class ContentDetailedResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double Duration { get; set; }
        public bool IsDownloadable { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Percentage { get; set; }
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public DateTime? Completed { get; set; }

        public string CourseId { get; set; } = string.Empty;
    }
}
