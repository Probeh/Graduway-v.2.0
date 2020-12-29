import { Observable   } from 'rxjs'
import { tap          } from 'rxjs/operators'
import { HttpClient   } from '@angular/common/http'
import { Injectable   } from '@angular/core'
import { environment  } from '@env/environment'
import { EmployeeTask } from '@models/employee-task'

@Injectable()
export class EmployeeTaskService {
  // ======================================= //
  private _baseUrl: string = `${environment.api}/tasks`;
  private _employeeTasks: EmployeeTask[];
  // ======================================= //
  constructor(private http: HttpClient) { }
  // ======================================= //
  public createTask(task: EmployeeTask): Observable<EmployeeTask[]> {
    return new Observable<EmployeeTask[]>(emitter => {
      this.http
        .put<EmployeeTask>(this._baseUrl, task)
        .toPromise()
        .then(result => this._employeeTasks.push(result))
        .then(() => emitter.next(this._employeeTasks.slice()))
    })
  }
  public getTasks(employeeId: number): Observable<EmployeeTask[]> {
    return this.http.get<EmployeeTask[]>(`${this._baseUrl}/${employeeId}`)
      .pipe(tap(result => this._employeeTasks = result));
  }
  public updateTask(task: EmployeeTask): Observable<EmployeeTask[]> {
    return new Observable<EmployeeTask[]>(emitter => {
      this.http
        .post<EmployeeTask>(this._baseUrl, task)
        .toPromise()
        .then(result => {
          this._employeeTasks.splice(this._employeeTasks.findIndex(x => x.id == result.id), 1, result);
          emitter.next(this._employeeTasks.slice());
        });
    });
  }
  public removeTask(id: number): Observable<EmployeeTask[]> {
    return new Observable<EmployeeTask[]>(emitter => {
      this.http
        .delete(`${this._baseUrl}/${id}`)
        .toPromise()
        .then(() => {
          this._employeeTasks.splice(this._employeeTasks.findIndex(x => x.id == id), 1);
          emitter.next(this._employeeTasks.slice());
        });
    });
  }
}
