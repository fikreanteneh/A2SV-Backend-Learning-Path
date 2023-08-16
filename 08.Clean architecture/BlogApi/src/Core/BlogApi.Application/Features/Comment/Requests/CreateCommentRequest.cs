




using BlogApi.Application.DTO.Comment;
using BlogApi.Application.Response;
using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;

public class CreatCommentRequest : IRequest<BaseCommandResponse>
{
    public CreateCommentDto createComment { get; set; }
}