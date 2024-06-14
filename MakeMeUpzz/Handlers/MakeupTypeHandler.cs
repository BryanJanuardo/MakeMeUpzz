using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using MakeMeUpzz.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MakeMeUpzz.Handlers
{
    public class MakeupTypeHandler
    {
        private static Response<int> generateNewMakeupTypeId()
        {
            int newId = 1;
            int latestId = (from x in MakeupTypeRepository.getAllMakeupType() select x.MakeupTypeID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return Response<int>.createResponse("Generate new Id success", true, newId);
        }

        public static Response<List<MakeupType>> getAllMakeupType()
        {
            List<MakeupType> makeupTypes = MakeupTypeRepository.getAllMakeupType();
            return Response<List<MakeupType>>.createResponse("Get all makeup types success!", true, makeupTypes);
        }

        public static Response<int> getMakeupTypeIdByName(string name)
        {
            int MakeupTypeId = MakeupTypeRepository.getMakeupTypeIdByName(name);
            return Response<int>.createResponse("Get makeup type id by name success!", true, MakeupTypeId);
        }

        public static Response<MakeupType> deleteMakeupType(int id)
        {
            MakeupTypeRepository.deleteMakeupType(id);
            return Response<MakeupType>.createResponse("Delete makeup type success!", true, null);
        }

        public static Response<MakeupType> insertNewMakeupType(string name)
        {
            MakeupType newMakeupType = MakeupTypeFactory.createMakeupType(generateNewMakeupTypeId().value, name);
            MakeupTypeRepository.insertNewMakeupType(newMakeupType);

            return Response<MakeupType>.createResponse("Insert makeup type success!", true, null);
        }

        public static Response<MakeupType> updateMakeupType(int id, string name)
        {
            MakeupTypeRepository.updateMakeupType(id, name);

            return Response<MakeupType>.createResponse("Update makeup type success!", true, null);
        }

        public static Response<List<string>> getAllMakeupTypeName()
        {
            List<MakeupType> makeupTypes = MakeupTypeRepository.getAllMakeupType();
            List<string> makeupTypesName = (from type in makeupTypes select type.MakeupTypeName).ToList();

            return Response<List<string>>.createResponse("Get all makeup type name success!", true, makeupTypesName);
        }

        public static Response<MakeupType> getMakeupTypeByName(string name)
        {
            List<MakeupType> makeupTypes = MakeupTypeRepository.getAllMakeupType();
            MakeupType makeupType = (from type in makeupTypes where type.MakeupTypeName == name select type).FirstOrDefault();

            return Response<MakeupType>.createResponse("Get makeup type by name success!", true, makeupType);

        }

        public static Response<MakeupType> getMakeupTypeById(int id)
        {
            List<MakeupType> makeupTypes = MakeupTypeRepository.getAllMakeupType();
            MakeupType makeupType = (from type in makeupTypes where type.MakeupTypeID == id select type).FirstOrDefault();

            return Response<MakeupType>.createResponse("Get makeup type by name success!", true, makeupType);
        }
    }
}