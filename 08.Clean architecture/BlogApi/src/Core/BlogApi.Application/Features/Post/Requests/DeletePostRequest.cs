

using MediatR;


namespace BlogApi.Application.Features.Requests;

public class DeletePostRequest : IRequest
{
    public int Id { get; set; }
}
