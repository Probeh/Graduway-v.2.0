import { CommonModule          } from '@angular/common'                                   ;
import { NgModule              } from '@angular/core'                                     ;
import { ReactiveFormsModule   } from '@angular/forms'                                    ;
import { EmployeeTaskComponent } from '@employee-task/employee-task.component'            ;
import { TaskDetailsComponent  } from '@employee-task/task-details/task-details.component';
import { EmployeeTaskService   } from '@services/employee-task.service'                   ;

const components = [EmployeeTaskComponent, TaskDetailsComponent];

@NgModule({
  imports      : [CommonModule          , ReactiveFormsModule ],
  declarations : [EmployeeTaskComponent, TaskDetailsComponent ],
  providers    : [EmployeeTaskService                         ],
  exports: components
})
export class EmployeeTaskModule { }
