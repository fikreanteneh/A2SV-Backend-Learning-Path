

using BlogApi.Application.DTO.Post;
using MediatR;


namespace BlogApi.Application.Features.Post.Requests;


public class UpdatePostRequest : IRequest<Unit>
{
    public UpdatePostDto updatePost { get; set; }
}
