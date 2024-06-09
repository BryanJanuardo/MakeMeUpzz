using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class UserRepository
    {
        public static List<User> getAllUser()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.Users.ToList();
        }

        public static void insertNewUser(User newUser)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.Users.Add(newUser);
            db.SaveChangesAsync();
        }
    }
}