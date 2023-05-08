namespace Ostral.Domain.Models
{
	public class StudentCourse
	{
		public string StudentId { get; set; } = string.Empty;
		public Student Student { get; set; }

		public string CourseId { get; set; } = string.Empty;
		public Course Course { get; set; }
		public double CompletionRate { get; set; }
		public DateTime CompletionDate { get; set; }

		public StudentCourse()
		{
			Student = new Student();
			Course = new Course();
		}
	}
}
