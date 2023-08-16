


using BlogApi.Application.Persistence.Contracts;
using FluentValidation;

namespace BlogApi.Application.DTO.Post.Validators;
public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidator(IPostRepository postRepository)
    {
        Include(new IPostDtoValidator());
        RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
        {
            var exist = await postRepository.Exists(id);
            return exist;
        }).WithMessage("Post not found");
    }
}