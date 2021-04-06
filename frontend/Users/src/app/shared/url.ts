import { environment } from '../../environments/environment';


let SERVER = environment.server;
 let UserEndPoint = SERVER + 'User/';
 let DepartmentEndPoint = SERVER + 'Department/';

export let APIURL = {
    User: {
        getUsers: `${UserEndPoint}getUsers`,
        getUser: `${UserEndPoint}getUser/`,
        AddUser: `${UserEndPoint}AddUser`,
        EditUser: `${UserEndPoint}EditUser/`,
        DeleteUser: `${UserEndPoint}DeleteUser/`
    },
    Department: {
        GetDepartments: `${DepartmentEndPoint}GetDepartments/`,
        GetDepartment: `${DepartmentEndPoint}GetDepartment/`,
        AddDepartment: `${DepartmentEndPoint}AddDepartment`,
        EditDepartment: `${DepartmentEndPoint}EditDepartment/`,
        DeleteDepartment: `${DepartmentEndPoint}DeleteDepartment/`
    }
}