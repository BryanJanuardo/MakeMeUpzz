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
    }
}