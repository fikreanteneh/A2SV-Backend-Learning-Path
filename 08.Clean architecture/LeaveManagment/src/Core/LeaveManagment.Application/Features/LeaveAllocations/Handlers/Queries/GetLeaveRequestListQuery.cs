

using AutoMapper;
using LeaveManagment.Application.DTO;
using LeaveManagment.Application.Features.LeaveAllocation.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
{

    ILeaveAllocationRepository _leaveAllocationRepository;
    Mapper _mapper;
    public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveTypeRepository, Mapper mapper)
    {
        _leaveAllocationRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    async Task<List<LeaveAllocationDto>> IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>.Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveAllocationRepository.GetAll();
        return _mapper.Map<List<LeaveAllocationDto>>(leaveTypes);
    }
}