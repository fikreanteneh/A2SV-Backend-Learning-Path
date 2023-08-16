




using BlogApi.Application.DTO.Post;
using MediatR;


namespace BlogApi.Application.Features.Post.Requests;


public class GetPostListRequest : IRequest<List<PostListDto>>
{
    
}