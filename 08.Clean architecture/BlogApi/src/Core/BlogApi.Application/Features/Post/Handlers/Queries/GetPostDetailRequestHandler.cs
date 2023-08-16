

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Requests;
using BlogApi.Application.DTO.Post;
using BlogApi.Application.Persistence.Contracts;

public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, PostDto>
{

    IPostRepository _postRepository;
    Mapper _mapper;
    public GetPostDetailRequestHandler(IPostRepository postRepository, Mapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        return _mapper.Map<PostDto>(post);
    }
}