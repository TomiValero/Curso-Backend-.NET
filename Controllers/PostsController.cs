using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
         IPostsService _titleservice;

        public PostsController(IPostsService titleService)
        {
            _titleservice = titleService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get()
        {
            return await _titleservice.Get();
        }
    }
}
