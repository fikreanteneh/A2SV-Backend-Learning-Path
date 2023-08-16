
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Post;
public class UpdatePostDto : BaseDto, IPostDto
{
    public string Title { get; set; }  
    public string Content { get; set; }    

}