



using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Requests.Commands;
public class DeleteLeaveAllocationRequest : IRequest<Unit>
{
    public int Id { get; set; }
}