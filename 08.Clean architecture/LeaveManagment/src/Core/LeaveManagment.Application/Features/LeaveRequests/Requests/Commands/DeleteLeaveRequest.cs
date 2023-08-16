



using LeaveManagment.Application.DTO.LeaveRequest;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
public class DeleteLeaveRequestRequest : IRequest<Unit>
{
    public int Id { get; set; }
}