



using LeaveManagment.Application.DTO;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}