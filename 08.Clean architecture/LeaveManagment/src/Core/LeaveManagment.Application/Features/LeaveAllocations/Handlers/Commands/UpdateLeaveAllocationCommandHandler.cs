
using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Requests.Commands;
public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationRequest>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    Mapper _mapper;
    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper){
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveManagement.Domain.LeaveAllocation>(request.LeaveAllocationDto);
        await _leaveAllocationRepository.Update(leaveAllocation);
        return Unit.Value;
    }
}