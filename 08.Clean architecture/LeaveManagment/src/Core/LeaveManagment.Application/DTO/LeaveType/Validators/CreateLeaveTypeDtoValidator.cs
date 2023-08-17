
using FluentValidation;
using LeaveManagment.Application.DTO.LeaveType;

namespace LeaveManagement.Application.DTO.LeaveType.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
    }
}