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
        private static Response<int> generateNewMakeupBrandId()
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

            return Response<int>.createResponse("Generate new id success!", true, newId);
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

        public static Response<MakeupBrand> insertNewMakeupBrand(string name, int rating)
        {
            MakeupBrand newMakeupBrand = MakeupBrandFactory.createMakeupBrand(generateNewMakeupBrandId().value, name, rating);
            MakeupBrandRepository.insertNewMakeupBrand(newMakeupBrand);

            return Response<MakeupBrand>.createResponse("Insert makeup brand success!", true, null);
        }

        public static Response<MakeupBrand> editNewMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand newMakeupBrand = MakeupBrandFactory.createMakeupBrand(id, name, rating);
            MakeupBrandRepository.editMakeupBrand(newMakeupBrand);

            return Response<MakeupBrand>.createResponse("Edit makeup brand success!", true, null);
        }

        public static Response<MakeupBrand> deleteMakeupBrand(int id)
        {
            MakeupBrandRepository.deleteMakeupBrand(id);

            return Response<MakeupBrand>.createResponse("Delete makeup brand success!", true, null);
        }
    }
}