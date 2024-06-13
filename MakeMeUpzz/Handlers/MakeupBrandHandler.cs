using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
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
            int latestId = (from x in getAllMakeupBrand() select x.MakeupBrandID).ToList().LastOrDefault();

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

        public static List<MakeupBrand> getAllMakeupBrand()
        {
            List<MakeupBrand> makeupBrands = MakeupBrandRepository.getAllMakeUpBrand();
            return makeupBrands;
        }

        public static int getMakeupBrandIdByName(string name)
        {
            int brandId = MakeupBrandRepository.getMakeupBrandIdByName(name);
            return brandId;
        }

        public static void insertNewMakeupBrand(string name, int rating)
        {
            MakeupBrand newMakeupBrand = MakeupBrandFactory.createMakeupBrand(generateNewMakeupBrandId(), name, rating);
            MakeupBrandRepository.insertNewMakeupBrand(newMakeupBrand);
        }
    }
}