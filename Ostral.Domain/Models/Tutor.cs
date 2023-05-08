namespace Ostral.Domain.Models
{
    public class Tutor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public double TotalRevenue { get; set; }
        public ICollection<Course> CourseList { get; set; }

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }


        public Tutor()
        {
            User = new User();
            CourseList = new HashSet<Course>();
        }
    }
}
