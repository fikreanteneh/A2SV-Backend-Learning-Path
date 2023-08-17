

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Comment.Requests;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.DTO.Comment;

namespace BlogApi.Application.Features.Comment.Handlers.Queries;
public class GetCommentListRequestHandler : IRequestHandler<GetCommentPostRequest, List<CommentDto>>
{

    ICommentRepository _commentRepository;
    Mapper _mapper;
    public GetCommentListRequestHandler(ICommentRepository commentRepository, Mapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> Handle(GetCommentPostRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAll();
        return  _mapper.Map<List<CommentDto>>(comments);
    }
}