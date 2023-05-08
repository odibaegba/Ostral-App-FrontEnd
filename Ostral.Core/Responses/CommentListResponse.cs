using Ostral.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Responses
{

    public class CommentListResponse
    {
        public IEnumerable<CommentListItem> Comments { get; set; }
    }
    public class CommentListItem
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }



    }


}
