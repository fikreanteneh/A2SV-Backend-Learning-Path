

namespace BlogApi.Application.DTO.Comment;
public class CreateCommentDto : ICommentDto
{
    public string Text {get; set;}
    public int PostId { get; set; }    

}