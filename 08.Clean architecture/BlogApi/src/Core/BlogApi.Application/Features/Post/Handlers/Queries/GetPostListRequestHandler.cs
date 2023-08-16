

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Requests;
using BlogApi.Application.DTO.Post;
using BlogApi.Application.Persistence.Contracts;

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