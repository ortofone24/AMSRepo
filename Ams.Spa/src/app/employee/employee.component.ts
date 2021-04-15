import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employees: Employee[] = [];

  headElements = ['Employee number', 'First name', 'Last name', 'Gender', 'Salary', 'Title', 'Hire date', 'Birth day'];

  page = 1;
  totalPages = 0;
  pageSize = 3;
  nextPage = '';
  previousPage = '';
  firstPage = '';
  lastPage = '';

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.retrieveData();
  }

  retrieveData()  {
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.employees = emp.data);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.page = emp.pageNumber);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.totalPages = emp.totalPages);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.pageSize = emp.pageSize);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.nextPage = emp.nextPage);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.previousPage = emp.previousPage);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.firstPage = emp.firstPage);
    this.employeeService.getEmployeeWithoutParms().subscribe(emp => this.lastPage = emp.lastPage);
  }

  nextPageMethod() {
      this.employeeService.getEmployeeWithParms(this.nextPage).subscribe(emp => this.employees = emp.data);
      this.employeeService.getEmployeeWithParms(this.nextPage).subscribe(emp => this.nextPage = emp.nextPage);
      this.employeeService.getEmployeeWithParms(this.nextPage).subscribe(emp => this.previousPage = emp.previousPage);
  }

  previousPageMethod() {
    this.employeeService.getEmployeeWithParms(this.previousPage).subscribe(emp => this.employees = emp.data);
    this.employeeService.getEmployeeWithParms(this.previousPage).subscribe(emp => this.nextPage = emp.nextPage);
    this.employeeService.getEmployeeWithParms(this.previousPage).subscribe(emp => this.previousPage = emp.previousPage);
  }

  firstPageMethod() {
    this.employeeService.getEmployeeWithParms(this.firstPage).subscribe(emp => this.employees = emp.data);
    this.employeeService.getEmployeeWithParms(this.firstPage).subscribe(emp => this.nextPage = emp.nextPage);
    this.employeeService.getEmployeeWithParms(this.firstPage).subscribe(emp => this.previousPage = emp.previousPage);
  }

  lastPageMethod() {
    this.employeeService.getEmployeeWithParms(this.lastPage).subscribe(emp => this.employees = emp.data);
    this.employeeService.getEmployeeWithParms(this.lastPage).subscribe(emp => this.nextPage = emp.nextPage);
    this.employeeService.getEmployeeWithParms(this.lastPage).subscribe(emp => this.previousPage = emp.previousPage);
  }
}
