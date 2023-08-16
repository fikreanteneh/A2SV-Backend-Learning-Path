

using LeaveManagment.Application.DTO.Common;
namespace LeaveManagment.Application.DTO;
public class CreateLeaveTypeDto : BaseDto
{
        public string Name { get; set; } = default!;
        public int DefaultDays { get; set; }

}