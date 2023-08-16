
using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;
using BlogApi.Application.DTO.Post.Validators;
using BlogApi.Application.Exceptions;
using BlogApi.Application.Response;

namespace BlogApi.Application.Features.Post.Handlers.Commands;
public class CreatePostCommandHandler : IRequestHandler<CreatPostRequest, BaseCommandResponse>
{
    IPostRepository _postRepository;
    Mapper _mapper;
    public CreatePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;

    }

    public async Task<BaseCommandResponse> Handle(CreatPostRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.createPost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = _mapper.Map<Domain.Post>(request.createPost);
        await _postRepository.Add(post);
        response.Id = post.Id;
        response.Message = "Post created successfully";
        response.Success = true;
        response.Errors = null;  
        return response;
    }
}