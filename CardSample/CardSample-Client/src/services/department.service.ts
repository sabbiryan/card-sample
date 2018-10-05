import { Injectable } from "@angular/core";

import { Http, Response } from "@angular/http";

import { Observable, of, from } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {Department} from "../models/department";

@Injectable()

export class DepartmentService {

  private deparmtentApi: string;

  constructor(private http: Http) {

    this.deparmtentApi = "http://localhost:55700/api/Department";
  }

  getAllDepartments(): Observable<any> {
    return this.http.get(this.deparmtentApi)
      .pipe(map((response: Response) => response.json()))
      .pipe(catchError(this.handleError('getAllDepartments', [])));
  }

  createDepartment(department: Department) {
    console.log(department);
    return this.http.post(this.deparmtentApi, department);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
     
      console.error(error); 

      //this.log(`${operation} failed: ${error.message}`);
     
      return of(result as T);
    };
  }

}
