// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Features.Comment.Requests;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;
public class DeletePostCommandHandler : IRequestHandler<DeleteCommentRequest, Unit>
{
    ICommentRepository _commentRepository;
    Mapper _mapper;
    public DeletePostCommandHandler(ICommentRepository commentRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.Id);
        await _commentRepository.Update(comment);
        return Unit.Value;
    }
}