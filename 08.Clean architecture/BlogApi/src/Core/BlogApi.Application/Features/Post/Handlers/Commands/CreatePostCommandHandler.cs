
using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;
using BlogApi.Application.DTO.Post.Validators;
using BlogApi.Application.Exceptions;

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
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.createPost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = _mapper.Map<Domain.Post>(request.createPost);
        await _postRepository.Add(post);
        return post.Id;
    }
}