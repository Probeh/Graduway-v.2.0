import { EmployeeTaskModule                    } from 'src/app/employee-task/employee-task.module'
import { HTTP_INTERCEPTORS  , HttpClientModule } from '@angular/common/http'
import { NgModule                              } from '@angular/core'
import { BrowserModule                         } from '@angular/platform-browser'
import { AppRoutingModule                      } from '@app/app-routing.module'
import { AppComponent                          } from '@app/app.component'
import { NavigationComponent                   } from '@app/navigation/navigation.component'
import { EmployeeComponent                     } from '@employees/employee.component'
import { RequestInterceptor                    } from '@services/request.interceptor'

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    EmployeeTaskModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    EmployeeComponent,
    NavigationComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
