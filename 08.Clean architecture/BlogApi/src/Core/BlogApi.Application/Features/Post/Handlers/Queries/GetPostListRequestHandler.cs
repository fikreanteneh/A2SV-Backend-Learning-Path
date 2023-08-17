

using AutoMapper;
using MediatR;
using BlogApi.Application.DTO.Post;
using BlogApi.Application.Contracts.Persistence;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Post.Handlers.Queries;

public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<PostListDto>>
{

    IPostRepository _postRepository;
    Mapper _mapper;
    public GetPostListRequestHandler(IPostRepository postRepository, Mapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostListDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAll();
        
        return _mapper.Map<List<PostListDto>>(posts);
    }
}