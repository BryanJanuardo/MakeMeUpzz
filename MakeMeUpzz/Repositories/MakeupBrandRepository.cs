using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupBrandRepository
    {
        public static List<MakeupBrand> getAllMakeUpBrand()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.MakeupBrands.ToList();
        }

        public static int getMakeupBrandIdByName(string name)
        {
            DatabaseContextEntities db = Singleton.getDB();
            string makeupBrandId = (from brand in db.MakeupBrands where brand.MakeupBrandName == name select brand.MakeupBrandID).FirstOrDefault().ToString();
            return Convert.ToInt32(makeupBrandId);
        }

        public static void insertNewMakeupBrand(MakeupBrand newMakeupBrand)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.MakeupBrands.Add(newMakeupBrand);
            db.SaveChanges();
        }

        public static void editMakeupBrand(MakeupBrand newMakeupBrand)
        {
            DatabaseContextEntities db = Singleton.getDB();
            MakeupBrand makeupBrand = db.MakeupBrands.Find(newMakeupBrand.MakeupBrandID);
            makeupBrand.MakeupBrandName = newMakeupBrand.MakeupBrandName;
            makeupBrand.MakeupBrandRating = newMakeupBrand.MakeupBrandRating;
            db.SaveChanges();
        }

        public static void deleteMakeupBrand(int id)
        {
            DatabaseContextEntities db = Singleton.getDB();
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            db.MakeupBrands.Remove(makeupBrand);
            db.SaveChanges();
        }
    }
}