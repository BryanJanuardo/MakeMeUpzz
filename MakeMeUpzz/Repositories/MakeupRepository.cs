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
           
        public static Makeup getMakeupById(int id)
        {
            DatabaseContextEntities db = Singleton.getDB();
            Makeup makeup = db.Makeups.Find(id);
            return makeup;
        }

        public static void editMakeup(Makeup newMakeup)
        {
            DatabaseContextEntities db = Singleton.getDB();
            Makeup makeup = db.Makeups.Find(newMakeup.MakeupID);
            makeup.MakeupName = newMakeup.MakeupName;
            makeup.MakeupPrice = newMakeup.MakeupPrice;
            makeup.MakeupWeight = newMakeup.MakeupWeight;
            makeup.MakeupBrandID = newMakeup.MakeupBrandID;
            makeup.MakeupTypeID = newMakeup.MakeupTypeID;
            db.SaveChanges();
        }

        public static void deleteMakeup(int id)
        {
            DatabaseContextEntities db = Singleton.getDB();
            Makeup makeup = db.Makeups.Find(id);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }
    }
}