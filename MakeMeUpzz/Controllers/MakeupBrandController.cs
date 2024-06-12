using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupBrandController
    {
        public static List<string> getMakeupBrandName()
        {
            List<string> makeupBrandNames = (from brand in MakeupBrandHandler.getAllMakeupBrand() select brand.MakeupBrandName).ToList();
            return makeupBrandNames;
        }
    }
}