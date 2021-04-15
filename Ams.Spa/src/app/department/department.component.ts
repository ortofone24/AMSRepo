import { Component, OnInit } from '@angular/core';
import { Department } from '../models/department';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  departments: Department[] = [];
  headElements = ['Department', 'First name', 'Last name'];

  constructor(private departmentService: DepartmentService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.departmentService.getDepartments().subscribe((departments: Department[]) => {
      this.departments = departments;
    }, error => {
      console.log(error);
    });
  }

}
