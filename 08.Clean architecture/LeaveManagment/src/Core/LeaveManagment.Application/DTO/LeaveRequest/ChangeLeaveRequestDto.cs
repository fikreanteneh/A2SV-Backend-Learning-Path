
using LeaveManagment.Application.DTO.Common;
namespace LeaveManagment.Application.DTO.LeaveRequest;


public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool Approved { get; set; }
}