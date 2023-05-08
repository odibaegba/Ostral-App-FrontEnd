using Ostral.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Responses
{
    public class CommentResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<Like> Likes { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string ParentCommentId { get; set; } = string.Empty;


        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }

      
        public CommentResponse(string userId, string courseId)

        {

            UserId = userId;

            CourseId = courseId;

            Likes = new HashSet<Like>();
            

        }
    }
}
