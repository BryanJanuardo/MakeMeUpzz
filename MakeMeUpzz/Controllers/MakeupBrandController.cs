using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
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

        public static Response<List<MakeupBrand>> getAllMakeupBrand()
        {
            Response<List<MakeupBrand>> response = MakeupBrandHandler.getAllMakeupBrand();
            return response;
        }

        public static Response<MakeupBrand> validationNewMakeupBrand(string name, string rating)
        {
            try
            {
                if (name == null)
                {
                    return Response<MakeupBrand>.createResponse("Brand name must be filled", false, null);
                }
                else if (name.Length <= 0 && name.Length > 100)
                {
                    return Response<MakeupBrand>.createResponse("Length brand name must be between 1 - 99 characters", false, null);
                }
                else if (rating == null)
                {
                    return Response<MakeupBrand>.createResponse("Rating must be filled", false, null);
                }
                else if (Convert.ToInt32(rating) < 0 && Convert.ToInt32(rating) > 100)
                {
                    return Response<MakeupBrand>.createResponse("Rating must be between 0 - 100", false, null);
                }
            }
            catch(Exception ex)
            {
                return Response<MakeupBrand>.createResponse("Rating must be number", false, null);
            }
            
            return Response<MakeupBrand>.createResponse("Validation makeup brand success!", true, null);
        }

        public static Response<MakeupBrand> insertNewMakeupBrand(string name, int rating)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.insertNewMakeupBrand(name, rating);
            return response;
        }

        public static Response<MakeupBrand> editMakeupBrand(int id, string name, int rating)
        {
            Response<MakeupBrand> reponse = MakeupBrandHandler.editNewMakeupBrand(id, name, rating);
            return reponse;
        }

        public static Response<MakeupBrand> deleteMakeupBrand(int id)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.deleteMakeupBrand(id);
            return response;
        }

        public static Response<MakeupBrand> getMakeupBrandById(int id)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.getMakeupBrandById(id);
            return response;
        }
    }
}