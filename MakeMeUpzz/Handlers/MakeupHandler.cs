using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
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
        private static Response<int> generateNewMakeupId()
        {
            int newId = 1;
            int latestId = (from makeup in MakeupRepository.getAllMakeup() select makeup.MakeupID).ToList().LastOrDefault();

            if(latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return Response<int>.createResponse("New Makeup Id Generated!", true, newId);
        }
        public static  Response<List<Makeup>> getAllMakeup()
        {
            List<Makeup> makeups = MakeupRepository.getAllMakeup();
            return Response<List<Makeup>>.createResponse("Get all makeups success!", true, makeups);
        }
        public static Response<Makeup> insertNewMakeup(string name, int price, int weight, string type, string brand)
        {
            int typeId = MakeupTypeHandler.getMakeupTypeIdByName(type).value;
            int brandId = MakeupBrandHandler.getMakeupBrandIdByName(brand).value;
            Makeup newMakeup = MakeupFactory.createMakeup(generateNewMakeupId().value, name, price, weight, typeId, brandId);

            MakeupRepository.insertNewMakeup(newMakeup);

            return Response<Makeup>.createResponse("Makeup Inserted!", true, null);
        }

        public static Response<Makeup> getMakeupById(int id)
        {
            Makeup makeup = MakeupRepository.getMakeupById(id);

            return Response<Makeup>.createResponse("Get makeup by id success!", true, makeup);
        }

        public static Response<Makeup> editMakeup(int id, string name, int price, int weight, string type, string brand)
        {
            int typeId = MakeupTypeHandler.getMakeupTypeIdByName(type).value;
            int brandId = MakeupBrandHandler.getMakeupBrandIdByName(brand).value;
            Makeup newMakeup = MakeupFactory.createMakeup(id, name, price, weight, typeId, brandId);
            MakeupRepository.editMakeup(newMakeup);

            return Response<Makeup>.createResponse("Makeup Edited!", true, null);
        }
        public static Response<Makeup> deleteMakeup(int id)
        {
            MakeupRepository.deleteMakeup(id);

            return Response<Makeup>.createResponse("Makeup Deleted!", true, null);
        }
    }
}