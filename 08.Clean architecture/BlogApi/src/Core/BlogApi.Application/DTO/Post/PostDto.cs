
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Post;
public class PostDto : BaseDto
{
    public string Title { get; set;} 
    public string Content {get; set;}
}