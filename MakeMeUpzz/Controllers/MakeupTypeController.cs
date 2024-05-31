using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupTypeController
    {
        public static List<string> getAllMakeupTypeName()
        {
            List<string> makeupTypeNames = (from type in MakeupTypeHandler.getAllMakeupType() select type.MakeupTypeName).ToList();
            return makeupTypeNames;
        }
    }
}