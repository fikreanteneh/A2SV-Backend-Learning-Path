
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Comment;
public class UpdateCommentDto : BaseDto, ICommentDto
{
    public string Text { get; set; }   
    public int PostId { get; set; } 
}