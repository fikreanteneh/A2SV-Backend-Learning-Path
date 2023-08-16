



using AutoMapper;
using LeaveManagment.Application.DTO.LeaveType;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
{
    ILeaveTypeRepository _leaveTypeRepository;
    Mapper _mapper;

    public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, Mapper mapper){
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;

    }

    async Task<LeaveTypeDto> IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>.Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);
        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}
