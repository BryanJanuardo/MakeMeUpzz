using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupBrandHandler
    {
        
        private static int generateNewMakeupBrandId()
        {
            int newId = 1;
            int latestId = (from x in MakeupBrandRepository.getAllMakeUpBrand() select x.MakeupBrandID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return newId;
        }

        public static Response<List<MakeupBrand>> getAllMakeupBrand()
        {
            List<MakeupBrand> makeupBrands = MakeupBrandRepository.getAllMakeUpBrand();
            return Response<List<MakeupBrand>>.createResponse("Get all makeup brands success!", true, makeupBrands);
        }

        public static Response<int> getMakeupBrandIdByName(string name)
        {
            int brandId = MakeupBrandRepository.getMakeupBrandIdByName(name);
            return Response<int>.createResponse("Get makeup brand id by name success!", true, brandId);
        }

        public static Response<List<string>> getAllMakeupBrandName()
        {
            List<string> brandName = (from brand in getAllMakeupBrand().value select brand.MakeupBrandName).ToList();
            return Response<List<string>>.createResponse("Get all makeup brand name success!", true, brandName);
        }

        public static void insertNewMakeupBrand(string name, int rating)
        {
            MakeupBrand newMakeupBrand = MakeupBrandFactory.createMakeupBrand(generateNewMakeupBrandId(), name, rating);
            MakeupBrandRepository.insertNewMakeupBrand(newMakeupBrand);
        }

        public static void editNewMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand newMakeupBrand = MakeupBrandFactory.createMakeupBrand(id, name, rating);
            MakeupBrandRepository.editMakeupBrand(newMakeupBrand);
        }
        public static void deleteMakeupBrand(int id)
        {
            MakeupBrandRepository.deleteMakeupBrand(id);
        }
    }
}