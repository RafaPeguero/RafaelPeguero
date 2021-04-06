import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APIURL } from '../shared/url';
import { IUser } from '../models/User.Model';
import { IDepartment } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private readonly http: HttpClient) { }

  getUsers(){
    return this.http.get(`${APIURL.User.getUsers}`);
  }

  getUser(user_id: number) {
    return this.http.get(`${APIURL.User.getUser + user_id}`);
  }

  AddUser(user:IUser)
  {
    return this.http.post(APIURL.User.AddUser,user);
  }

  DeleteUser(user_id: number)
  {
    return this.http.delete(`${APIURL.User.DeleteUser + user_id}`);
  }

  EditUser(id:number, User:IUser)
  {
    return this.http.put(`${APIURL.User.EditUser + id}`, User);
  }

  GetDepartments()
  {
    return this.http.get(`${APIURL.Department.GetDepartments}`);
  }

  GetDepartment(department_id: number)
  {
    return this.http.get(`${APIURL.Department.GetDepartment + department_id}`);
  }

  AddDepartment(Department: IDepartment)
  {
    return this.http.post(APIURL.Department.AddDepartment, Department);
  }

  DeleteDepartment(department_id: number)
  {
    return this.http.delete(`${APIURL.Department.DeleteDepartment + department_id}`)
  }

  EditCustomerAdress(department_id: number, department: IDepartment)
  {
    return this.http.put(`${APIURL.Department.EditDepartment + department_id }`, department);
  }
}
