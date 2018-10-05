import { Component } from '@angular/core';

import { DepartmentService } from "../services/department.service";
import { Department } from "../models/department";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DepartmentService]
})



export class AppComponent {
  title = 'CardSample-Client';

  departments: Department[];
  model: Department;

  ngOnInit() {
    
    this.getAllDepartments();    
  }

  constructor(private departmentService: DepartmentService) {

    this.model = new Department();
  }



  getAllDepartments() {

    this.departmentService.getAllDepartments()
      .subscribe(
        //data => console.log(data), 
        //data => this.departments = data, 
        data => {
          this.departments = data;
          console.log(data);
        },
        error => console.log(error)
      );
  }



  createDepartment(isValid: boolean) {

    if (!isValid) return;

    this.departmentService.createDepartment(this.model)
      .subscribe(
        data => {
          console.log(data);
          this.model = new Department();
        },
        error => {
          console.log(error);
        }
      );
  };

}
