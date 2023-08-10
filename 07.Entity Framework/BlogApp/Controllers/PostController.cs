using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Services;
using BlogApp.Validator;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controller;


[Route("[controller]")]
[ApiController]
public class PostsController : ControllerBase{
    private readonly ApiDbContext _context ;
    private readonly PostManager _postManager;
    public PostsController(ApiDbContext context){
        _context = context;
        _postManager = new PostManager(_context);
    }

    //Get methods domain/Posts  ---> return all posts
    [HttpGet]
    public IActionResult Get(){
        try{
            return Ok(_postManager.GetAllPosts());
        }
        catch (CustomException e){
            return StatusCode(404, e.Message);
        }
        catch (Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    //Post methods domain/Posts  ---> return created post and its get link
    [HttpPost]
    public IActionResult Create([FromBody] CreatePostDto post){
        try{
            Post createdPost =  _postManager.CreatePost(new Post(){
                Title = post.Title,
                Content = post.Content,
            });
            return CreatedAtAction(nameof(Get), new {id = createdPost.Id}, createdPost);
        }
        catch (CustomException e){
            return StatusCode(404, e.Message);
        }
        catch(Exception){
            return StatusCode(500, " server error");
        }
    }

    //Put methods domain/Posts/postId  ---> return updated post 
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdatePostDto updatedPost){
        try{
            Post post = _postManager.UpdatePost(
            new Post(){
                Id = id,
                Title = updatedPost.Title,
                Content = updatedPost.Content,
            });
            return Ok(post);
        }
        catch(CustomException e){
            return StatusCode(404, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    //Delete methods domain/Posts/postId  ---> return NOContent 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        try{
            _postManager.DeletePost(id);
            return NoContent();
        }
        catch(CustomException e){
            return StatusCode(404, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }

}