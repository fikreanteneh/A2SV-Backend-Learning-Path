

namespace BlogApi.Application.DTO.Post;
public class CreatePostDto : IPostDto
{
    public string Title {get; set;}
    public string Content { get; set; }    

}