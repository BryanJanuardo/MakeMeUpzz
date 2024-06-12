using MakeMeUpzz.Factories;
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
        private static int generateNewMakeupTypeId()
        {
            int newId = 1;
            int latestId = (from x in getAllMakeupType() select x.MakeupTypeID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return newId;
        }

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

        public static void insertNewMakeupType(string name)
        {
            MakeupType newMakeupType = MakeupTypeFactory.createMakeupType(generateNewMakeupTypeId(), name);
            MakeupTypeRepository.insertNewMakeupType(newMakeupType);
        }

        public static void updateMakeupType(int id, string name)
        {
            MakeupTypeRepository.updateMakeupType(id, name);
        }
    }
}