using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.RepositortAbstracts
{
    public interface IUser
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(int id);
        User Find(int id);
        ICollection<User> Search(UserSearchType SearchType, string value);
    }
    public enum UserSearchType
    {
        All = 0,
        UserId = 1,
        Username = 2,
        RegisterDate = 3,
    }
}

