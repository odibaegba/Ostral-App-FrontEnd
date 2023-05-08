using AutoMapper;
using Microsoft.Extensions.Configuration;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Requests;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly string _baseUrl;
        private readonly IMapper _mapper;

        public CommentService(IHttpClientService httpClientService, IConfiguration configuration, IMapper mapper)
        {
            _httpClientService = httpClientService;
            _baseUrl = configuration.GetValue<string>("BaseApiUrl")!;
            _mapper = mapper;

        }

      

        public async Task<ResponseVM<CommentResponse>> AddCommentAsync(string courseId, string comment, string userId)
        {
            var addComment = _mapper.Map<CommentRequest>(comment);

            var result = await _httpClientService.PostRequestAsync<CommentRequest, ResponseVM<CommentResponse>>(_baseUrl, ApiRoutes.Comment.AddComment(courseId), addComment);

            return result;
        }

        public async Task<ResponseVM<IEnumerable<CommentListItem>>> GetAllCommentsAsync(string courseId)
        {
            var result = await _httpClientService.GetRequestAsync<ResponseVM<IEnumerable<CommentListItem>>>(_baseUrl, ApiRoutes.Comment.GetAllComments(courseId));

            return result;
        }


        public async Task<ResponseVM<CommentResponse>> GetCommentById(string commentId)
        {
            var result = await _httpClientService.GetRequestAsync<ResponseVM<CommentResponse>>(_baseUrl, ApiRoutes.Comment.GetCommentById(commentId));

            return result;
        }

        public async Task<ResponseVM<CommentResponse>> ToggleLikeAsync(string commentId, string userId)
        {
            var result = await _httpClientService.GetRequestAsync<ResponseVM<CommentResponse>>(_baseUrl, ApiRoutes.Comment.ToggleLike(commentId));

            return result;
        }
    }
}
