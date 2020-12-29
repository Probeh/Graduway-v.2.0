import { Component } from '@angular/core';
import { Employee } from '@models/employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public selectedEmployee: Employee;
  // ======================================= //
  public onSelectedEmployee(employee: Employee) {
    this.selectedEmployee = employee;
  }
}
