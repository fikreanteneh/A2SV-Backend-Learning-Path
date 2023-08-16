


using BlogApi.Application.Persistence.Contracts;
using FluentValidation;

namespace BlogApi.Application.DTO.Comment.Validators;

public class UpdateCommentDtoCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoCommentDtoValidator(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        Include(new ICommentDtoValidator(postRepository));
        RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
        {
            var exist = await commentRepository.Exists(id);
            return exist;
        }).WithMessage("Comment not found");
    }
}