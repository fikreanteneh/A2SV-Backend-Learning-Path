

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.DTO.Post;
using BlogApi.Application.Contracts.Persistence;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Post.Handlers.Queries;
 

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
        if (post == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }
        return _mapper.Map<PostDto>(post);
    }
}