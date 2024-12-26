using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;
namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly PostService  _postService;
    public PostsController()
    {
        _postService = new PostService();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
    [HttpGet]
    public ActionResult<List<Post>> GetPosts()
    {
        return new List<Post>
        {
            new() { Id = 1, UserId = 1, Title = "Post1", Body = "The first post." },
            new() { Id = 2, UserId = 1, Title = "Post2", Body = "The second post." },
            new() { Id = 3, UserId = 1, Title = "Post3", Body = "The third post." }
        };
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        await _postService.CreatePost(post);
        return CreatedAtAction(nameof(GetPost), new {id = post.Id}, post);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }
        var updatedPost = await _postService.UpdatePost(id, post);
        if (updatedPost == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
}