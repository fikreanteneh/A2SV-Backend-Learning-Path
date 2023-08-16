
using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    ILeaveTypeRepository _leaveTypeRepository;
    Mapper _mapper;
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, Mapper mapper){
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;

    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);
        leaveType = await _leaveTypeRepository.Add(leaveType);
        return leaveType.Id;
    }
}