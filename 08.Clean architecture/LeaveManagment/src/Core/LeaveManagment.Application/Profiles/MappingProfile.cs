


using LeaveManagement.Domain;
using LeaveManagment.Application.DTO;

namespace LeaveManagment.Application.Profile;
public class MappingProfile: AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
    }
}