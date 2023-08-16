



using AutoMapper;
using LeaveManagment.Application.DTO;
using LeaveManagment.Application.Features.LeaveAllocation.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;


namespace LeaveManagment.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
{
    ILeaveAllocationRepository _leaveAlloationRepository;
    Mapper _mapper;

    public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveTypeRepository, Mapper mapper){
        _leaveAlloationRepository = leaveTypeRepository;
        _mapper = mapper;

    }

    async Task<LeaveAllocationDto> IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>.Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAlloationRepository.Get(request.Id);
        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}
