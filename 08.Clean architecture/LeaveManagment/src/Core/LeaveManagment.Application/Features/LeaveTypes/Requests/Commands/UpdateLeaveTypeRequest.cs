

using LeaveManagment.Application.DTO.LeaveType;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }

    }