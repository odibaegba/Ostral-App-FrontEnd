namespace Ostral.Domain.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string TutorName { get; set; } = string.Empty;
        public string? Description { get; set; }
		public string? CoverUrl { get; set; }
		public double Price { get; set; }
        public int Duration { get; set; }
        public decimal Percentage { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletionTime { get; set; }

        public string TutorId { get; set; } = string.Empty;
        public Tutor Tutor { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public Category Category { get; set; }
        public ICollection<Content> ContentList { get; set; }
        public ICollection<Student> StudentList { get; set; }
        public ICollection<Comment> Comments { get; set; }


        public Course()
        {
            Tutor = new Tutor();
            Category = new Category();
            ContentList = new HashSet<Content>();
            StudentList = new HashSet<Student>();
            Comments = new HashSet<Comment>();
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
