


using LeaveManagement.Domain;
using LeaveManagment.Application.DTO.LeaveAllocation;
using LeaveManagment.Application.DTO.LeaveRequest;
using LeaveManagment.Application.DTO.LeaveType;


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