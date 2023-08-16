

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Comment.Requests;
using BlogApi.Application.DTO.Post;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Application.DTO.Comment;

namespace BlogApi.Application.Features.Comment.Handlers.Queries;
public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentDto>>
{

    ICommentRepository _commentRepository;
    Mapper _mapper;
    public GetCommentListRequestHandler(ICommentRepository postRepository, Mapper mapper)
    {
        _commentRepository = postRepository;
        _mapper = mapper;
    }

    public Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
    {
        
    }
}