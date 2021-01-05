using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;
namespace _5__Web_NET_Web_Api_and_SQL
{
    public class EmployeeSecurity 
    {
        public bool Login(string username , string password)
        {
            using(EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Users.Any(user => user.Username.Equals(username,
                    StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}