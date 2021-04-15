import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RootObject, RootObjectEmployee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getEmployeeWithoutParms():  Observable<RootObjectEmployee>{
  return this.http.get<RootObjectEmployee>(this.baseUrl + '/Employee')
}

getEmployeeWithParms(url: string):  Observable<RootObjectEmployee>{
      
  return this.http.get<RootObjectEmployee>(url)
}

}
