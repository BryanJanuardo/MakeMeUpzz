using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand createMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand newMakeupBrand = new MakeupBrand()
            {
                MakeupBrandID = id,
                MakeupBrandName = name,
                MakeupBrandRating = rating
            };
            return newMakeupBrand;
        }
    }
}