



using LeaveManagment.Application.DTO.LeaveRequest;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
public class UpdateLeaveRequestRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public UpdateLeaveRequestDto LeaveRequestDto { get; set; }
    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }

}