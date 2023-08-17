

using AutoMapper;
using MediatR;
using BlogApi.Application.Features.Comment.Requests;
using BlogApi.Application.Contracts.Persistence;
using BlogApi.Application.DTO.Comment;
using BlogApi.Application.Exceptions;

namespace BlogApi.Application.Features.Comment.Handlers.Queries;
public class GetCommentPostRequestHandler : IRequestHandler<GetCommentPostRequest, List<CommentDto>>
{

    ICommentRepository _commentRepository;
    Mapper _mapper;
    public GetCommentPostRequestHandler(ICommentRepository postRepository, Mapper mapper)
    {
        _commentRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> Handle(GetCommentPostRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetByPost(request.Id);
        if (comments == null)
        {
            throw new NotFoundException(nameof(comments), request.Id);
        }
        return  _mapper.Map<List<CommentDto>>(comments);
    }
}