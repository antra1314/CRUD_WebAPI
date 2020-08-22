using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetWebApi.Models
{
    public class Repository : IRepository
    {
         List<User> users = new List<User>();

        public Repository()
        {
            users.Add(new User { ID = 1, Name = "Antra", Address = "edinburgh" });
            users.Add(new User { ID = 2, Name = "Alok", Address = "fashion street" });
            users.Add(new User { ID = 3, Name = "Anaika", Address = "picaso" });
            users.Add(new User { ID = 4, Name = "abc", Address = "glasgow" });
            users.Add(new User { ID = 5, Name = "xyz", Address = "london" });

        }

        public User Add(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }

            users.Add(user);
            return user;
        }

        public User Get(int id)
        {
            return users.Find(m => m.ID == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Remove(int id)
        {
            users.RemoveAll(m => m.ID == id);
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            int index = users.FindIndex(m => m.ID == user.ID);
            if (index == -1)
            { return false; }
            users.RemoveAt(index);
            users.Add(user);
            return true;
                  }
    }
}