



using AutoMapper;
using LeaveManagment.Application.DTO;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
{
    ILeaveRequestRepository _leaveRequestRepository;
    Mapper _mapper;

    public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveTypeRepository, Mapper mapper){
        _leaveRequestRepository = leaveTypeRepository;
        _mapper = mapper;

    }

    async Task<LeaveRequestDto> IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>.Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveRequestRepository.Get(request.Id);
        return _mapper.Map<LeaveRequestDto>(leaveType);
    }
}
