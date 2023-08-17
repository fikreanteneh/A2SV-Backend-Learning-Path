
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Comment;
public class CommentDto : BaseDto, ICommentDto
{
    public string Text { get; set;} 
    public int PostId {get; set;}   
}