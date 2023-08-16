
using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands;
public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestRequest, int>
{
    ILeaveRequestRepository _leaveRequestRepository;
    Mapper _mapper;
    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, Mapper mapper){
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;

    }

    public async Task<int> Handle(CreateLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = _mapper.Map<LeaveRequest>(request.createLeaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
        return leaveRequest.Id;
    }
}