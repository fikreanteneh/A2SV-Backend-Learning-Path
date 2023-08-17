
using FluentValidation;
using LeaveManagment.Application.DTO.LeaveRequest;

namespace LeaveManagement.Application.DTO.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    public CreateLeaveRequestDtoValidator()
    {
        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {comparisonValue}");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {comparisonValue}");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty();

    }
}