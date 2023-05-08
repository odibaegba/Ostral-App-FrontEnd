using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.Services;
using System.Security.Claims;

namespace Ostral.WEB.Controllers
{
    [Route("comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("getallcomments/{courseId}")]
        public async Task<IActionResult> GetAllComments(string courseId)
        {
            
            var result = await _commentService.GetAllCommentsAsync(courseId);
            return result == null ? NotFound() : View(result.Data);
        }

       

        [HttpPost("addcomment")]
        public async Task<IActionResult> AddComment(string courseID, string comment, string userId)
        {
            var result = await _commentService.AddCommentAsync(courseID, comment, userId);
            return View("GetAllComments", result);


           // return View(result);
        }
        [HttpPost("like")]
        public async Task<IActionResult> ToggleLike(string commentId, string userId)
        {
            var result = await _commentService.ToggleLikeAsync(commentId,userId);
            return RedirectToAction("GetAllComments", result);
        }

        [Route("{id}")]
        public async Task<ActionResult> Details([FromRoute] string id)
        {
            
            var result = await _commentService.GetCommentById(id);
            return result == null ? NotFound() : View(result.Data);
        }
    }
}
