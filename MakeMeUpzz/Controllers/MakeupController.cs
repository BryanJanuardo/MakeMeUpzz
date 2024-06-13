using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        public static Response<Makeup> validationNewMakeup(string name, int price, int weight, string type, string brand)
        {
            try
            {
                if (name == string.Empty)
                {
                    return Response<Makeup>.createResponse("Name must be filled!", false, null);
                }
                else if (type == string.Empty)
                {
                    return Response<Makeup>.createResponse("Type must be filled!", false, null);
                }
                else if (brand == string.Empty)
                {
                    return Response<Makeup>.createResponse("Brand must be filled!", false, null);
                }
                else if (name.Length < 1 || name.Length > 99)
                {
                    return Response<Makeup>.createResponse("Name length must be 1-99!", false, null);
                }
                else if (price < 1)
                {
                    return Response<Makeup>.createResponse("Price must be more or equal than 1!", false, null);
                }
                else if (weight < 1 || weight > 1500)
                {
                    return Response<Makeup>.createResponse("Weight must be 1-1500!", false, null);
                }
            }
            catch(Exception e)
            {
                return Response<Makeup>.createResponse("Input Price and Weight must be number", false, null);
            }

            return Response<Makeup>.createResponse("Input validated!", true, null);
        }
        public static Response<Makeup> insertNewMakeup(string name, int price, int weight, string type, string brand)
        {
            Response<Makeup> response = MakeupHandler.insertNewMakeup(name, price, weight, type, brand);
            return response;
        }
        public static Response<List<Makeup>> getAllMakeupSortDescByRating()
        {
            Response<List<Makeup>> response = MakeupHandler.getAllMakeup();
            response.value = response.value.OrderByDescending(makeup => makeup.MakeupBrand.MakeupBrandRating).ToList();
            return response;
        }

        public static Response<List<Makeup>> getAllMakeup()
        {
            Response<List<Makeup>> response = MakeupHandler.getAllMakeup();
            return response;
        }

        public static Response<Makeup> getMakeupById(int id)
        {
            Response<Makeup> response = MakeupHandler.getMakeupById(id);
            return response;
        }

        public static Response<Makeup> editMakeup(int id, string name, int price, int weight, string type, string brand)
        {
            Response<Makeup> response = MakeupHandler.editMakeup(id, name, price, weight, type, brand);
            return response;
        }
        public static Response<Makeup> deleteMakeup(int id)
        {
            Response<Makeup> response = MakeupHandler.deleteMakeup(id);
            return response;
        }
    }
}