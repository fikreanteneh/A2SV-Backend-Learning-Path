// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Features.Comment.Requests;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;
public class UpdatePostCommandHandler : IRequestHandler<UpdateCommentRequest, Unit>
{
    ICommentRepository _commentRepository;
    Mapper _mapper;
    public UpdatePostCommandHandler(ICommentRepository commentRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.updatedComment.Id);
        _mapper.Map(request.updatedComment, comment);        
        await _commentRepository.Update(comment);
        return Unit.Value;
    }
}