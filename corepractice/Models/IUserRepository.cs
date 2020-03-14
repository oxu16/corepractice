using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepractice.Models
{
    public interface IUserRepository
    {
        User GetUser(int Id);
        IEnumerable<User> GetAllUser();
        User Add(User employee);
        User Update(User employeeChanges);
        User Delete(int Id);
    }
}
