
using BlogApi.Application.DTO.Common;

namespace BlogApi.Application.DTO.Comment;
public class UpdateCommentDto : BaseDto
{
    public string Text { get; set; }    
}