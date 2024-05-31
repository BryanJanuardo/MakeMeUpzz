using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupFactory
    {
        public static Makeup createMakeup(int id, string name, int price, int weight, int typeID, int brandID)
        {
            Makeup newMakeup = new Makeup()
            {
                MakeupID = id,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeID,
                MakeupBrandID = brandID
            };
            return newMakeup;
        }
    }
}