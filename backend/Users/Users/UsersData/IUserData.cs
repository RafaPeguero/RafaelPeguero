using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.UsersData
{
    public interface IUserData
    {
        List<User> getUsers();
        User GetUser(string User_Id);

        User AddUser(User user);

        User EditUser(User user);

        void DeleteUser(User user);

        List<Department> GetDeparments();

        Department GetDeparment(int department_id);

        Department AddDeparment(Department department);

        Department EditDeparment(Department department);

        void DeleteDeparment(Department department);
    }
}
