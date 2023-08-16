


using FluentValidation;

namespace BlogApi.Application.DTO.Post.Validators;
public class IPostDtoValidator : AbstractValidator<IPostDto>
{
    public IPostDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
    }
}