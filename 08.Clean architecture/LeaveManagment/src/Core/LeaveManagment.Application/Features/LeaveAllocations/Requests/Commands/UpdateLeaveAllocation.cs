



using LeaveManagment.Application.DTO.LeaveAllocation;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
public class UpdateLeaveAllocationRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }

}