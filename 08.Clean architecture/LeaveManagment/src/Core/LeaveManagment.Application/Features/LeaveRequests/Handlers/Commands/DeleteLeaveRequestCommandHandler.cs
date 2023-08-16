using AutoMapper;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagment.Application.Persistence.Contracts;
using MediatR;
namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestRequest>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly Mapper _mapper;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRepository, Mapper mapper)
        {
            _leaveRequestRepository = leaveRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveRequestRepository.Get(request.Id);
            await _leaveRequestRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
