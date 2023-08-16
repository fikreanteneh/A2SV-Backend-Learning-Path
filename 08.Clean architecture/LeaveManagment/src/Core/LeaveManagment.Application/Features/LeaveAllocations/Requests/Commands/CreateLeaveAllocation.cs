



using LeaveManagment.Application.DTO.LeaveAllocation;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
public class CreateLeaveAllocationRequest : IRequest<int>
{
    public CreateLeaveAllocationDto createLeaveAllocationDto { get; set; }
}