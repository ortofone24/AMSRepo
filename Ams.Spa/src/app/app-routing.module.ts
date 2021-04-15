import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangeManagerComponent } from './changeManager/changeManager.component';
import { DepartmentComponent } from './department/department.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  { path: 'department', component: DepartmentComponent},
  { path: 'employee', component: EmployeeComponent},
  { path: 'changeManager', component: ChangeManagerComponent},
  { path: '**', redirectTo: 'home', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
