
using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;


namespace BlogApi.Application.Features.Post.Handlers.Commands;
public class CreatePostCommandHandler : IRequestHandler<CreatPostRequest, int>
{
    IPostRepository _postRepository;
    Mapper _mapper;
    public CreatePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;

    }

    public async Task<int> Handle(CreatPostRequest request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Domain.Post>(request.createPost);
        await _postRepository.Add(post);
        return post.Id;
    }
}