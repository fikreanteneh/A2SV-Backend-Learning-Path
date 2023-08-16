



using LeaveManagment.Application.DTO.LeaveType;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}