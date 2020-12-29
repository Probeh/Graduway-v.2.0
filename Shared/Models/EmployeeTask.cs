using System;
using Shared.Enums;

namespace Shared.Models
{
  public class EmployeeTask : BaseModel
  {
    // ======================================= //
    public TimeSpan Estimate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskState State { get; set; }
    // ======================================= //
    //        Navigation Properties
    // ======================================= //
    public int? EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    // ======================================= //
    public EmployeeTask() : base() { }
    public EmployeeTask(string title, string description, int employeeId, TimeSpan estimate, TaskPriority priority = TaskPriority.Low, TaskState state = TaskState.New) : base(title, description)
    {
      this.Estimate = estimate;
      this.Priority = priority;
      this.State = state;
      this.EmployeeId = employeeId;
    }
    public EmployeeTask(int id, string title, string description, int employeeId, TimeSpan estimate, TaskPriority priority = TaskPriority.Low, TaskState state = TaskState.New) : this(title, description, employeeId, estimate, priority, state)
    {
      this.Id = id;
    }
  }
}