
using LeaveManagment.Application.DTO.LeaveType;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeDto leaveTypeDto {get; set;}
}

