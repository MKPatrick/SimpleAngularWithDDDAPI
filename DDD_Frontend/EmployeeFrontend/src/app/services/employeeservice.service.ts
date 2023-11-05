import { Injectable } from '@angular/core';
import { BaseResponse } from '../Models/basic-response';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; // Import the environment variable
import { Employee } from '../Models/employee';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseURL:string =environment.apiBaseURL+"Employee/";
  constructor(private http: HttpClient) { }

  getEmployees(): Observable<BaseResponse<Employee[]>> {
    return this.http.get<BaseResponse<Employee[]>>(this.baseURL + "GetEmployees");
  }

// Create a new employee
createEmployee(employee: Employee): Observable<BaseResponse<null>> {
   return this.http.post<BaseResponse<null>>(this.baseURL+"AddEmployee", employee);
}


// Read a single employee by ID
getEmployeeById(id: number): Observable<BaseResponse<Employee>> {
  
  return this.http.get<BaseResponse<Employee>>(this.baseURL + "GetEmployeeByID?id="+id);
}

// Update an employee by ID
updateEmployee( employee: Employee): Observable<BaseResponse<null>> {

  return this.http.put<BaseResponse<null>>(this.baseURL+"UpdateEmployee", employee);
}

// Delete an employee by ID
deleteEmployee(id: number): Observable<BaseResponse<null>> {
  return this.http.delete<BaseResponse<null>>(this.baseURL +"deleteEmployeeByID?id=" + id);
}


}
