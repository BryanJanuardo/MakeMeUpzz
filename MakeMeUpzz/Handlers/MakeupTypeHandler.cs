using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupTypeHandler
    {
        public static List<MakeupType> getAllMakeupType()
        {
            List<MakeupType> makeupTypes = MakeupTypeRepository.getAllMakeupType();
            return makeupTypes;
        }

        public static int getMakeupTypeIdByName(string name)
        {
            int MakeupTypeId = MakeupTypeRepository.getMakeupTypeIdByName(name);
            return MakeupTypeId;
        }
    }
}