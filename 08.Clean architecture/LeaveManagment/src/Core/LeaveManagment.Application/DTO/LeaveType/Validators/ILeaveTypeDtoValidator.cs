


using FluentValidation;
using LeaveManagment.Application.DTO.LeaveRequest;
using LeaveManagment.Application.Persistence.Contracts;

public class ILeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public ILeaveRequestDtoValidator(ILeaveRequestDtoValidator leaveRequestDtoValidator)
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
            .MustAsync(async (id, cancellation) =>
            {
                var leaveType = await _leaveTypeRepository.Exist(id);
                return leaveType != null;
            })
            .WithMessage("{PropertyName} does not exist")
            .NotEmpty();

    }

}