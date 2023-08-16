

using AutoMapper;
using LeaveManagment.Application.DTO;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
{

    ILeaveTypeRepository _leaveTypeRepository;
    Mapper _mapper;
    public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, Mapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    async Task<List<LeaveTypeDto>> IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>.Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAll();
        return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
}