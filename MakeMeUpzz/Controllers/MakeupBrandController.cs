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
    }
}