using System;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.DTOs
{
    public class TaskCreateDTO : BaseDTO
    {
        [Required, Range(1, int.MaxValue)]
        public int EmployeeId { get; set; }

        [Required, DataType(DataType.Time)]
        public TimeSpan Estimate { get; set; }

        [Required, EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        [Required, EnumDataType(typeof(TaskState))]
        public TaskState State { get; set; }
    }
}