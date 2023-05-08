namespace Ostral.Domain.Models
{
    public class Content
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public double Duration { get; set; }
        public bool IsCompletd { get; set; }
        public bool IsDownloadable { get; set; }
        public decimal Percentage { get; set; }
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public DateTime CompletionTime { get; set; }

        public string CourseId { get; set; } = string.Empty;
        public Course Course { get; set; }

        public Content()
        {
            Course = new Course();
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}