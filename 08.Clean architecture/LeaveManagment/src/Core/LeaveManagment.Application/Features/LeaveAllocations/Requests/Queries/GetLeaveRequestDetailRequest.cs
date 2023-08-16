



using LeaveManagment.Application.DTO.LeaveAllocation;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Requests.Queries;
public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}