using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.Repositories
{
    public class UserRepository : IUser
    {
        public bool Add(User user)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                user.RegisterDate = DateTime.Now;
                user.Deleted = false;
                contaxt.Users.Add(user);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var user = contaxt.Users.FirstOrDefault(p => p.UserId == id);
                user.Deleted = true;
                user.DeletedByUserId = DatabaseTools.GetUserID;
                user.DeletedDate = DateTime.Now;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }

        public User Find(int id)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                return contaxt.Users.FirstOrDefault(p => p.UserId == id);
            }
            catch
            {
                return null;
            }
        }

        public ICollection<User> Search(UserSearchType SearchType, string value)
        {
            List<InventoryApp.Entities.User> List = new List<Entities.User>();
            var contaxt = new DataLayer.InventoryDBContext();
            switch (SearchType)
            {
                case UserSearchType.UserId:
                    {
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            var _user = contaxt.Users.Where(p => p.UserId == id).ToList();
                            List.AddRange(_user);
                        }
                        return List;
                    }
                case UserSearchType.RegisterDate:
                    {
                        var _user = contaxt.Users.Where(p => p.RegisterDate==DateTime.Parse(value)).ToList();
                        List.AddRange(_user);
                        return List;
                    }
                case UserSearchType.Username:
                    {
                        var _user = contaxt.Users.Where(p => p.Username == value).ToList();
                        List.AddRange(_user);
                        return List;
                    }
                case UserSearchType.All:
                    {
                        var _user = contaxt.Users.Where(p => p.RegisterDate == DateTime.Parse(value)).ToList();
                        List.AddRange(_user);
                        _user = contaxt.Users.Where(p => p.Username == value).ToList();
                        List.AddRange(_user);
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                             _user = contaxt.Users.Where(p => p.UserId == id).ToList();
                            List.AddRange(_user);
                        }
                        return List;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Update(User user)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var _user = contaxt.Users.FirstOrDefault(p => p.UserId == user.UserId);
                _user = user;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
