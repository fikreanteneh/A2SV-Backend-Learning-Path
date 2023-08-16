// update command handler for post


using AutoMapper;
using MediatR;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.Features.Comment.Requests;

namespace BlogApi.Application.Features.Comment.Handlers.Commands;
public class CreatePostCommandHandler : IRequestHandler<CreatCommentRequest, int>
{
    ICommentRepository _commentRepository;
    Mapper _mapper;
    public CreatePostCommandHandler(ICommentRepository commentRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }


    public async Task<int> Handle(CreatCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Add(_mapper.Map<Domain.Comment>(request.createComment));
        return comment.Id;
    }
}