




using BlogApi.Application.DTO.Post;
using BlogApi.Application.Response;
using MediatR;


namespace BlogApi.Application.Features.Post.Requests;

public class CreatPostRequest : IRequest<BaseCommandResponse>
{
    public CreatePostDto createPost { get; set; }
}