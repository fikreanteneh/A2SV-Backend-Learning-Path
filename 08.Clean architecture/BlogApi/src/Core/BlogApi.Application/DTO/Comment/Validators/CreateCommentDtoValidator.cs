


using BlogApi.Application.Contracts.Persistence;
using FluentValidation;

namespace BlogApi.Application.DTO.Comment.Validators;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator(IPostRepository postRepository)
    {
        Include(new ICommentDtoValidator(postRepository));
    }
}