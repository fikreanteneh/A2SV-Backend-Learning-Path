// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Features.Comment.Requests;
using BlogApi.Application.DTO.Comment.Validators;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;
public class CreatePostCommandHandler : IRequestHandler<CreatCommentRequest, int>
{
    ICommentRepository _commentRepository;
    IPostRepository _postRepository;
    
    Mapper _mapper;
    public CreatePostCommandHandler(ICommentRepository commentRepository,IPostRepository postRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _mapper = mapper;
    }


    public async Task<int> Handle(CreatCommentRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.createComment);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var comment = await _commentRepository.Add(_mapper.Map<Domain.Comment>(request.createComment));
        return comment.Id;
    }
}