using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.UsersData
{
    public class SqlUserData: IUserData
    {
        private UserContext _UserContext;
        public SqlUserData(UserContext context)
        {
            _UserContext = context;
        }

        public Department AddDeparment(Department department)
        {
            _UserContext.Department.Add(department);
            _UserContext.SaveChanges();
            return department;
        }

        public User AddUser(User user)
        {
            _UserContext.User.Add(user);
            _UserContext.SaveChanges();
            return user;
        }

        public void DeleteDeparment(Department department)
        {
            _UserContext.Department.Remove(department);
            _UserContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _UserContext.User.Remove(user);
            _UserContext.SaveChanges();
        }

        public Department EditDeparment(Department department)
        {
            var existingDepartment = _UserContext.Department.Find(department.Department_ID);
            if (existingDepartment != null)
            {
                existingDepartment.Department_Name = department.Department_Name;

                _UserContext.Department.Update(existingDepartment);
                _UserContext.SaveChanges();
            }
            return department;
        }

        public User EditUser(User user)
        {
            try
            {
                var existingUser = _UserContext.User.Find(user.User_ID);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.LastName = user.LastName;
                    existingUser.Birthday = user.Birthday;
                    existingUser.Gender = user.Gender;
                    existingUser.ImmediateSupervisor = user.Gender;
                    existingUser.Department_ID = user.Department_ID;
                    existingUser.position = user.position;

                    _UserContext.User.Update(existingUser);
                    _UserContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return user;
        }

        public Department GetDeparment(int department_id)
        {
            return _UserContext.Department.SingleOrDefault(x => x.Department_ID == department_id);
        }

        public List<Department> GetDeparments()
        {
            return _UserContext.Department.ToList();
        }

        public User GetUser(string User_Id)
        {
            return _UserContext.User.SingleOrDefault(x => x.User_ID == User_Id);
        }

        public List<User> getUsers()
        {
            return _UserContext.User.ToList();
        }
    }
}
