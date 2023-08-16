


using FluentValidation;

namespace BlogApi.Application.DTO.Post.Validators;
public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator()
    {
        Include(new IPostDtoValidator());
    }
}