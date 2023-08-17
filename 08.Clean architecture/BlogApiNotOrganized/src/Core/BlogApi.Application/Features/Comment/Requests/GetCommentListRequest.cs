




using BlogApi.Application.DTO.Comment;
using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;


public class GetCommentListRequest : IRequest<List<CommentDto>>
{
    
}