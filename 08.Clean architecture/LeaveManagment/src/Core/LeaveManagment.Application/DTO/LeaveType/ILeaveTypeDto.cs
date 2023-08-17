using LeaveManagment.Application.DTO.Common;
namespace LeaveManagment.Application.DTO.LeaveType;



public interface LeaveTypeDto : BaseDto {
        public string Name { get; set; } = default!;
        public int DefaultDays { get; set; }
}
