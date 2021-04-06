import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IMyDateModel, IMyDpOptions } from 'mydatepicker';
import { IUser } from '../models/User.Model';
import { UserServiceService } from '../services/user-service.service';
import { IDepartment } from '../models/department.model';
import * as moment from 'moment';

@Component({
  selector: 'app-user-component',
  templateUrl: './user-component.component.html'
})
export class UserComponentComponent implements OnInit {

  public Users: IUser[] = [];
  public Departments: IDepartment[] = [];
  public AddUserForm: FormGroup;
  public FormIsInvalid: boolean = false;
  public SelectedUserId: number;

  myDatePickerOptions: IMyDpOptions = {
    // other options...
    dateFormat: 'yyyy-mm-dd',
};

genders = [
  { id: 'M', name: 'Male' },
  { id: 'F', name: 'Female' },
  { id: 'N/S', name: 'Not specified' },
  { id: 'NoBinario', name: 'non-binary' },
];


  constructor(public _UserService: UserServiceService,
    private readonly formBuilder: FormBuilder) { }

  ngOnInit() {
    this.CreateFormAddUser();
    this.getUsers();
    this.getDepartments();
  }


  CreateFormAddUser() {
    this.AddUserForm = this.formBuilder.group({

      User_ID: [null, Validators.required],
      Name: [null, Validators.required],
      LastName: [null, Validators.required],
      Gender: [null, Validators.required],
      Birthday: [null, Validators.required],
      position: [null, Validators.required],
      ImmediateSupervisor: [null, Validators.required],
      Department_ID: [null, Validators.required]
    });
  }

  getUsers() {
    this._UserService.getUsers().subscribe( (res: IUser[]) => {
      this.Users = res as IUser[];
    })
  }

  getDepartments()
  {
    this._UserService.GetDepartments().subscribe( (res: IDepartment[]) => {
      this.Departments = res as IDepartment[];
    })
  }

  GetCostumer(id: number) {
    this._UserService.getUser(id).subscribe((res: IUser) => {
     this.AddUserForm.patchValue({
      User_ID: res.user_ID,
      Name: res.name,
      LastName: res.lastName,
      Gender: res.gender,
      Birthday: res.birthday,
      position: res.position,
      ImmediateSupervisor: res.immediateSupervisor,
      Department_ID: res.department_ID
     })
    })
  }

  setDate(event: IMyDateModel ): void {
    this.AddUserForm.patchValue({myDate: {
      Birthday: event.formatted
    }});
}

clearDate(): void {
    // Clear the date using the patchValue function
    this.AddUserForm.patchValue({Birthday: null});
}



  Submit() {
    if(this.AddUserForm.invalid){
      this.FormIsInvalid = true;
      return
    } else {
      this.FormIsInvalid = false;
    }
    let Value = this.AddUserForm.value;
    let params: IUser = {
      user_ID: Value.User_ID,
      name: Value.Name,
      lastName: Value.LastName,
      gender: Value.Gender,
      birthday: Value.Birthday.jsdate,
      position: Value.position,
      immediateSupervisor: Value.ImmediateSupervisor,
      department_ID: Value.Department_ID
    }

    this.AddUser(params);

  }



  AddUser(params: IUser) {
    this._UserService.AddUser(params).subscribe(resp => {
      this.CompleteRegister();
    });
  }


  DeleteUser() {
    this._UserService.DeleteUser(this.SelectedUserId).subscribe( res => {
     this.getUsers();
    })
  }


  CompleteRegister() {
    this.getUsers();
    this.resetForm();

  }


  resetForm() {
    this.AddUserForm.reset();
    this.FormIsInvalid = false;
  }

}
