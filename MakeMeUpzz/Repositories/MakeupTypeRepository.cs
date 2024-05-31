using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupTypeRepository
    {
        public static List<MakeupType> getAllMakeupType()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.MakeupTypes.ToList();
        }

        public static int getMakeupTypeIdByName(string name)
        {
            DatabaseContextEntities db = Singleton.getDB();
            string makeupTypeId = ((from type in db.MakeupTypes where type.MakeupTypeName == name select type.MakeupTypeID).FirstOrDefault().ToString());
            return Convert.ToInt32(makeupTypeId);
        }
    }
}