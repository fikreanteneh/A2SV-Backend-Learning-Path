




using BlogApi.Application.DTO.Post;
using MediatR;


namespace BlogApi.Application.Features.Requests;

public class GetPostDetailRequest : IRequest<PostDto>
{
    public int Id { get; set; }
}