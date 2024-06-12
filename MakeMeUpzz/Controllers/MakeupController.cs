using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        public static string validationNewMakeup(string name, string price, string weight, string type, string brand)
        {
            if (name == null)
            {
                return "Name must be filled!";
            }

            else if (price == null)
            {
                return "Price must be filled!";
            }
            else if (weight == null)
            {
                return "Weight must be filled!";
            }
            else if (type == null)
            {
                return "Type must be filled!";
            }
            else if (brand == null)
            {
                return "Brand must be filled!";
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                return "Name length must be 1-99!";
            }
            else if (Convert.ToInt32(price) < 1)
            {
                return "Price must be more or equal than 1!";
            }
            else if (Convert.ToInt32(weight) < 1 || Convert.ToInt32(weight) > 1500)
            {
                return "Price must be 1-1500";
            }

            return "";
        }
        public static void insertNewMakeup(string name, int price, int weight, string type, string brand)
        {
            MakeupHandler.insertNewMakeup(name, price, weight, type, brand);
        }
        public static List<Makeup> getAllMakeupSortDescByRating()
        {
            return MakeupHandler.getAllMakeup().OrderByDescending(makeup => makeup.MakeupBrand.MakeupBrandRating).ToList();
        }

        public static List<Makeup> getAllMakeup()
        {
            return MakeupHandler.getAllMakeup().ToList();
        }

        public static Makeup getMakeupById(int id)
        {
            return MakeupHandler.getMakeupById(id);
        }

        public static void editMakeup(int id, string name, int price, int weight, string type, string brand)
        {
            MakeupHandler.editMakeup(id, name, price, weight, type, brand);
        }
        public static void deleteMakeup(int id)
        {
            MakeupHandler.deleteMakeup(id);
        }
    }
}