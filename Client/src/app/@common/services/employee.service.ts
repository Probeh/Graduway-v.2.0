import { Observable  } from 'rxjs'
import { tap         } from 'rxjs/operators'
import { HttpClient  } from '@angular/common/http'
import { Injectable  } from '@angular/core'
import { environment } from '@env/environment'
import { Employee    } from '@models/employee'

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  // ======================================= //
  private _baseUrl: string = `${environment.api}/employees`;
  private _employees: Employee[];
  // ======================================= //
  constructor(private http: HttpClient) { }
  // ======================================= //
  public getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this._baseUrl)
      .pipe(tap(result => this._employees = result));
  }
}
