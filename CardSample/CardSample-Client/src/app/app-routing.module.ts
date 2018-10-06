import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {AppComponent} from "./app.component";
import { EmployeeComponent } from "./employee/employee.component";
import { DepartmentComponent } from "./department/department.component";
import { DepartmentEmployeesComponent } from "./department-employees/department-employees.component";


const routes: Routes = [
  { path: "", component: DepartmentComponent },
  { path: "department/:id", component: DepartmentEmployeesComponent },
  { path: 'employee', component: EmployeeComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
