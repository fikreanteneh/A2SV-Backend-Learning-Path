




using BlogApi.Application.DTO.Comment;
using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;

public class CreatCommentRequest : IRequest<int>
{
    public CreateCommentDto createComment { get; set; }
}