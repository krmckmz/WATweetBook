using Microsoft.AspNetCore.Mvc;
using System;
using WATweetBook.Contracts;
using WATweetBook.Contracts.V1.Requests;
using WATweetBook.Contracts.V1.Responses;
using WATweetBook.Domain;
using WATweetBook.Services;

namespace WATweetBook.Controllers
{
    public class PostsController : Controller
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
             _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if(post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };

            if (post.Id != Guid.Empty)
                post.Id = Guid.NewGuid();

            var posts = _postService.GetPosts();
            posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created(locationUri, response);
        }
    }
}
