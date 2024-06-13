using MakeMeUpzz.Handlers;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupBrandController
    {
        public static Response<List<string>> getMakeupBrandName()
        {
            Response<List<string>> response = MakeupBrandHandler.getAllMakeupBrandName();
            return response;
        }

        public static string validationNewMakeupBrand(string name, string rating)
        {
            if(name == null)
            {
                return "Brand name must be filled";
            }
            else if(name.Length <= 0 && name.Length > 100)
            {
                return "Length brand name must be between 1 - 99 characters";
            }
            else if(rating == null)
            {
                return "Rating must be filled";
            }
            else if(Convert.ToInt32(rating) < 0 && Convert.ToInt32(rating) > 100)
            {
                return "Rating must be between 0 - 100";
            }
            return "";
        }

        public static void insertNewMakeupBrand(string name, int rating)
        {
            MakeupBrandHandler.insertNewMakeupBrand(name, rating);
        }

        public static void editMakeupBrand(int id, string name, int rating)
        {
            MakeupBrandHandler.editNewMakeupBrand(id, name, rating);
        }

        public static void deleteMakeupBrand(int id)
        {
            MakeupBrandHandler.deleteMakeupBrand(id);
        }
    }
}