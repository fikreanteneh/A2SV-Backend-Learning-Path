


using LeaveManagment.Application.DTO.Common;

namespace LeaveManagment.Application.DTO.LeaveAllocation;


public class UpdateLeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }