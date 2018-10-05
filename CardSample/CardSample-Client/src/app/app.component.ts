import { Component } from '@angular/core';

import { NotifierService } from 'angular-notifier';

import { DepartmentService } from "../services/department.service";
import { Department } from "../models/department";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DepartmentService, NotifierService]
})



export class AppComponent {
  title = 'CardSample-Client';
 
  departments: Department[];
  model: Department;
  isUpdateMode: boolean;

  ngOnInit() {
    
    this.getAllDepartments();    
  }

  constructor(private departmentService: DepartmentService, private  notifierService: NotifierService) {

    this.model = new Department();
    this.isUpdateMode = false;
  }



  getDepartment(id) {
    this.departmentService.getDepartment(id).subscribe(data => {
        this.model = data;
        this.notifierService.notify("info", "Data Loaded");
        this.isUpdateMode = true;
      },
      error => {
        this.notifierService.notify("error", "Failed To Load Data!");
      });
  }

  getAllDepartments() {

    this.departmentService.getAllDepartments()
      .subscribe(
        data => {
          this.departments = data;
          console.log(data);
        },
        error => console.log(error)
      );
  }


  updateDepartment(isValid: boolean) {

    if (!isValid) {
      this.notifierService.notify("error", "Form validation failed!");
      return;
    }

    this.departmentService.updateDepartment(this.model)
      .subscribe(
        data => {
          console.log(data);
          this.model = new Department();
          this.notifierService.notify("success", "Update Success");
          this.getAllDepartments();
          this.isUpdateMode = false;
        },
        error => {
          console.log(error);
          this.notifierService.notify("error", "Update Failed!");
        }
      );
  };

  createDepartment(isValid: boolean) {

    if (!isValid) {
      this.notifierService.notify("error", "Form validation failed!");
      return;
    }

    if (this.isUpdateMode) {
      this.updateDepartment(isValid);
      return;
    }

    this.departmentService.createDepartment(this.model)
      .subscribe(
        data => {
          console.log(data);
          this.model = new Department();
          this.notifierService.notify("success", "Create Success");
          this.getAllDepartments();
          this.isUpdateMode = false;
        },
        error => {
          console.log(error);
          this.notifierService.notify("error", "Create Failed!");
        }
      );
  };



  deleteDepartment(id) {
    this.departmentService.deleteDepartment(id).subscribe(data => {
        this.getAllDepartments();
        this.notifierService.notify("info", "Delete Success");
      },
      error => {
        this.notifierService.notify("error", "Delete Failed!");
      });
  }
}
