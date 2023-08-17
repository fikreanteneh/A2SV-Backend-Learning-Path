// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Post.Requests;
using BlogApi.Application.Contracts.Persistence;
using BlogApi.Application.DTO.Post.Validators;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Post.Handlers.Commands;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostRequest, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly Mapper _mapper;

    public UpdatePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdatePostDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.updatePost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = await _postRepository.Get(request.updatePost.Id);
        _mapper.Map(request.updatePost, post);        
        await _postRepository.Update(post);
        return Unit.Value;
    }
}