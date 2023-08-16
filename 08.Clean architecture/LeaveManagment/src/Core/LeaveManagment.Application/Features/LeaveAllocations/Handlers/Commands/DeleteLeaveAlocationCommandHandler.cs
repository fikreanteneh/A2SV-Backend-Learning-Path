
using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocation.Requests.Commands;
public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationRequest>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    Mapper _mapper;
    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, Mapper mapper){
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveManagement.Domain.LeaveAllocation>(request.Id);
        await _leaveAllocationRepository.Delete(leaveAllocation);
        return Unit.Value;
    }
}