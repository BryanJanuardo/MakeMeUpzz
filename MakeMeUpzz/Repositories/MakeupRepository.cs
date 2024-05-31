using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        public static List<Makeup> getAllMakeup()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.Makeups.ToList();
        }

        public static void insertNewMakeup(Makeup newMakeup)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.Makeups.Add(newMakeup);
            db.SaveChanges();
        }
    }
}