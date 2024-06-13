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
    }
}