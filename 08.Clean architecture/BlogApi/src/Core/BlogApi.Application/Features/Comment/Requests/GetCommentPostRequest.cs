




using BlogApi.Application.DTO.Comment;
using MediatR;


namespace BlogApi.Application.Features.Comment.Requests;


public class GetCommentPostRequest : IRequest<List<CommentDto>>
{
    public int Id { get; set; }
    
}