


using BlogApi.Application.Persistence.Contracts;
using FluentValidation;

namespace BlogApi.Application.DTO.Comment.Validators;

public class ICommentDtoValidator : AbstractValidator<ICommentDto> 
{
    public ICommentDtoValidator(IPostRepository postRepository)
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required");
        RuleFor(x => x.PostId).MustAsync(async (id, cancellation) =>
        {
            var exist = await postRepository.Exists(id);
            return  exist;
        }).WithMessage("Post not found");


    }
}

