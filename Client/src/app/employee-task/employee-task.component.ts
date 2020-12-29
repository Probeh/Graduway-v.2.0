import { Observable } from 'rxjs'
import { Component, Input, OnInit } from '@angular/core'
import { Employee } from '@models/employee'
import { EmployeeTask } from '@models/employee-task'
import { EmployeeTaskService } from '@services/employee-task.service'
import { FormControl, FormGroup, Validators } from '@angular/forms'

@Component({
  selector: 'app-employee-task',
  templateUrl: './employee-task.component.html',
  styleUrls: ['./employee-task.component.scss']
})
export class EmployeeTaskComponent implements OnInit {
  public taskForm: FormGroup;
  public currentEmployee: Employee;
  public $employeeTasks: Observable<EmployeeTask[]>;
  @Input() public set employee(value: Employee) { this.setEmployeeTasks(value); }
  // ======================================= //
  constructor(private service: EmployeeTaskService) { }
  ngOnInit() {
    this.taskForm = this.generateForm();
  }
  // ======================================= //
  private setEmployeeTasks(value: Employee) {
    if (value) {
      this.currentEmployee = value;
      this.$employeeTasks = this.service.getTasks(value.id);
    }
  }
  public onSelectedTask(item: EmployeeTask) {

  }
  public onCreateTask() {

  }
  public generateForm() {
    return new FormGroup({
      'estimate'   : new FormControl('', Validators.required),
      'priority'   : new FormControl('', Validators.required),
      'state'      : new FormControl('', Validators.required),
      'employeeId' : new FormControl('', Validators.required),
      'title'      : new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required)
    })
  }
}
