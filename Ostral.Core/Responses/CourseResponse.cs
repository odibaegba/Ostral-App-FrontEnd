using Ostral.Domain.Models;

namespace Ostral.Core.Responses
{
	public class CourseResponse
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string TutorId { get; set; } = string.Empty;
		public string TutorFullName { get; set; } = string.Empty;
		public string TutorImageUrl { get; set; } = string.Empty;
		public string TutorDescription { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public double Price { get; set; }
		public int Duration { get; set; }
		public bool IsCompleted { get; set; }
		public string CategoryId { get; set; } = string.Empty;
		public string CategoryName { get; set; } = string.Empty;
		public bool IsRegistered { get; set; }
		public ICollection<Content> ContentList { get; set; }
		public ICollection<StudentCourse> StudentList { get; set; }
        public ICollection<Comment> Comments { get; set; }


        public CourseResponse()
		{
			ContentList = new HashSet<Content>();
			StudentList = new HashSet<StudentCourse>();
			Comments = new HashSet<Comment>();
		}
	}
}
