

using BlogApi.Application.DTO.Comment;
using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;

public class UpdateCommentRequest : IRequest<Unit>
{
    public UpdateCommentDto updatedComment { get; set; }
}
