

using LeaveManagment.Application.DTO.Common;
namespace LeaveManagment.Application.DTO;
public class CreateLeaveAllocationDto : BaseDto
{
    public int NumberOfDays {get; set;}
    public int LeaveTypeId {get; set;}
    public int Period {get; set;}

}