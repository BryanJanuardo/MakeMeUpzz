using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType createMakeupType(int id, string name)
        {
            MakeupType newMakeupType = new MakeupType()
            {
                MakeupTypeID = id,
                MakeupTypeName = name,

            };
            return newMakeupType;
        }
    }
}