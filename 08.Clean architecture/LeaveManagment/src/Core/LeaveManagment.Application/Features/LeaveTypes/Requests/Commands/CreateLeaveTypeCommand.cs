
using LeaveManagment.Application.DTO;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeDto leaveTypeDto {get; set;}
}

