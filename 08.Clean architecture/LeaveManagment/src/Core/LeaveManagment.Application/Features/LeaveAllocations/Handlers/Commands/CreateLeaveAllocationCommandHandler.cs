
using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Handlers.Commands;
public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationRequest, int>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    Mapper _mapper;
    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper){
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;

    }

    public async Task<int> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveManagement.Domain.LeaveAllocation>(request.createLeaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }
}