using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlTest
{
    public interface IUserRepository
    {
        void CreateTable();
        void InsertUser(string username, string email);
        IEnumerable<User> GetAllUsers();
    }
}
