



using LeaveManagment.Application.DTO.LeaveRequest;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
public class CreateLeaveRequestRequest : IRequest<int>
{
    public CreateLeaveRequestDto createLeaveRequestDto { get; set; }
}