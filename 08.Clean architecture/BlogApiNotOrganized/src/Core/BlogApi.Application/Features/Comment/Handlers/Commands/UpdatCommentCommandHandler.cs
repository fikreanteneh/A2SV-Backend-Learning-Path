// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Features.Comment.Requests;
using BlogApi.Application.DTO.Comment.Validators;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;
public class UpdatePostCommandHandler : IRequestHandler<UpdateCommentRequest, Unit>
{
    ICommentRepository _commentRepository;
    IPostRepository _postRepository;
    Mapper _mapper;
    public UpdatePostCommandHandler(ICommentRepository commentRepository,IPostRepository postRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentDtoValidator(_postRepository, _commentRepository);
        var validationResult = await validator.ValidateAsync(request.updatedComment);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        
        var comment = await _commentRepository.Get(request.updatedComment.Id);
        _mapper.Map(request.updatedComment, comment);        
        await _commentRepository.Update(comment);
        return Unit.Value;
    }
}