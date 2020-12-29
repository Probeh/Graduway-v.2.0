import { Time         } from '@angular/common'          ;
import { TaskPriority } from '@enums/task-priority.enum';
import { TaskState    } from '@enums/task-state.enum'   ;
import { BaseModel    } from '@models/base-model'       ;

export class EmployeeTask extends BaseModel {
  // ======================================= //
  public estimate  : Time        ;
  public priority  : TaskPriority;
  public state     : TaskState   ;
  public employeeId: number      ;
  // ======================================= //
  constructor(id: number, description: string, title: string, created: Date, estimate: Time, priority: TaskPriority, state: TaskState, employeeId: number) {
    super(id, description, title, created);
    this.estimate   = estimate  ;
    this.priority   = priority  ;
    this.state      = state     ;
    this.employeeId = employeeId;
  }
  // ======================================= //
}
