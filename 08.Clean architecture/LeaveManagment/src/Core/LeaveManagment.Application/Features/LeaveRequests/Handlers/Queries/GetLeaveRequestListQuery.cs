

using AutoMapper;
using LeaveManagment.Application.DTO;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Queries;

// public class GetLeaveRequestListRequestHandler : IRequestHandler< GetLeaveRequestListRequest, List<LeaveRequestDto>>
// {

//     ILeaveRequestRepository _leaveTypeRepository;
//     Mapper _mapper;
//     public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveTypeRepository, Mapper mapper)
//     {
//         _leaveTypeRepository = leaveTypeRepository;
//         _mapper = mapper;
//     }

//     Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//         // var leaveTypes = _leaveTypeRepository.GetAll();
//         // return _mapper.Map<List<LeaveRequestDto>>(leaveTypes);
//     }
// }

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
{

    ILeaveTypeRepository _leaveTypeRepository;
    Mapper _mapper;
    public GetLeaveRequestListRequestHandler(ILeaveTypeRepository leaveTypeRepository, Mapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    async Task<List<LeaveRequestDto>> IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>.Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAll();
        return _mapper.Map<List<LeaveRequestDto>>(leaveTypes);
    }
}