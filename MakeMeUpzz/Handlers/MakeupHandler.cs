using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupHandler
    {
        private static int generateNewMakeupId()
        {
            int newId = 1;
            int latestId = (from makeup in getAllMakeup() select makeup.MakeupID).ToList().LastOrDefault();

            if(latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return newId;
        }
        public static List<Makeup> getAllMakeup()
        {
            List<Makeup> makeups = MakeupRepository.getAllMakeup();
            return makeups;
        }

        public static void insertNewMakeup(string name, int price, int weight, string type, string brand)
        {
            int typeId = MakeupTypeHandler.getMakeupTypeIdByName(type);
            int brandId = MakeupBrandHandler.getMakeupBrandIdByName(brand);
            Makeup newMakeup = MakeupFactory.createMakeup(generateNewMakeupId(),name, price, weight, typeId, brandId);
            MakeupRepository.insertNewMakeup(newMakeup);
        }
    }
}