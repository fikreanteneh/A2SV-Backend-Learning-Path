using LeaveManagment.Application.DTO.Common;

namespace LeaveManagment.Application.DTO;


public class LeaveAllocationDto : BaseDto {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; }

}
