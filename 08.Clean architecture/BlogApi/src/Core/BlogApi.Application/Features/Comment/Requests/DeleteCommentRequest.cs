

using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;


public class DeleteCommentRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
