

using MediatR;


namespace BlogApi.Application.Features.Post.Requests;


public class DeletePostRequest : IRequest<Unit>
{
    public int Id { get; set; }
}
