

namespace BlogApi.Application.DTO.Comment;
public interface ICommentDto
{
    string Text { get; set; }
    int PostId { get; set; }
}