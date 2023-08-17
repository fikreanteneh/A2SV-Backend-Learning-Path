using LeaveManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Domain;
public class LeaveType : BaseEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}