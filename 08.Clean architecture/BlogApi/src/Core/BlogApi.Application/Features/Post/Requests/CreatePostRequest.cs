




using BlogApi.Application.DTO.Post;
using MediatR;


namespace BlogApi.Application.Features.Requests;

public class CreatPostRequest : IRequest<int>
{
    public CreatePostDto createPost { get; set; }
}