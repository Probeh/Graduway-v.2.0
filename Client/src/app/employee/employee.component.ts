import { Observable } from 'rxjs'
import { Component, EventEmitter, OnInit, Output } from '@angular/core'
import { Employee } from '@models/employee'
import { EmployeeService } from '@services/employee.service'
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  public $employees: Observable<Employee[]>;
  public employee: Employee;
  @Output() public selectedEmployee: EventEmitter<Employee> = new EventEmitter<Employee>();
  // ======================================= //
  constructor(private service: EmployeeService) { }
  ngOnInit() {
    this.$employees = this.service.getEmployees()
      .pipe(tap(result => this.onSelectedEmployee(result[0])));
    this.selectedEmployee.subscribe(value => this.employee = value);
  }
  // ======================================= //
  public onSelectedEmployee(employee: Employee) {
    this.selectedEmployee.next(employee);
  }
}
