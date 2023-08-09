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
    [HttpGet]
    public IActionResult Get(){
        try{
            return Ok(_postManager.GetAllPosts());
        }
        catch (CustomException e){
            return StatusCode(400, e.Message);
        }
        catch (Exception){
            return StatusCode(500, "Internal server error");
        }
    }

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
            return StatusCode(400, e.Message);
        }
        catch(Exception){
            return StatusCode(500, " server error");
        }
    }

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
            return StatusCode(400, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        try{
            _postManager.DeletePost(id);
            return NoContent();
        }
        catch(CustomException e){
            return StatusCode(400, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    // [HttpPost("{postId}/comments")]
    // public IActionResult AddComment(int postId, [FromBody]CreateCommentDto comment){
    //     try{
    //         string addedComment = _commentManager.CreateComment(
    //             new Comment(){
    //                 PostId = postId,
    //                 Text = comment.Text,
    //             }
    //         );
    //         return Ok(addedComment);
    //     }
    //     catch (CustomException e){
    //         return StatusCode(400, e.Message);
    //     }
    //     catch (Exception){
    //         return StatusCode(500, "Internal server error");
    //     }
    // }

    // [HttpGet("{postId}/comments")]
    // public IActionResult GetComments(int postId){
    //     try{
    //         return Ok(_commentManager.GetAllComments(postId));
    //     }
    //     catch (CustomException e){
    //         return StatusCode(400, e.Message);
    //     }
    //     catch (Exception){
    //         return StatusCode(500, "Internal server error");
    //     }
    // }

    // [HttpPut("{postId}/comments/{commentId}")]
    // public IActionResult UpdateComment(int postId, int commentId, [FromBody] UpdateCommentDto updatedComment){
    //     try{
    //         return Ok(_commentManager.UpdateComment(
    //         new Comment(){
    //             Id = commentId,
    //             PostId = postId,
    //             Text = updatedComment.Text,
    //         }));
    //     }
    //     catch(CustomException e){
    //         return StatusCode(400, e.Message);
    //     }
    //     catch(Exception){
    //         return StatusCode(500, "Internal server error");
    //     }
    // }

    // [HttpDelete("{postId}/comments/{commentId}")]
    // public IActionResult DeleteComment(int postId, int commentId){
    //     try{
    //         return Ok(_commentManager.DeleteComment(commentId));
    //     }
    //     catch(CustomException e){
    //         return StatusCode(400, e.Message);
    //     }
    //     catch(Exception){
    //         return StatusCode(500, "Internal server error");
    //     }
    // }

}