
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Post;
public class UpdatePostDto : BaseDto
{
    public string Title { get; set; }  
    public string Content { get; set; }    

}