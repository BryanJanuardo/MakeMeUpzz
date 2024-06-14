using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MakeMeUpzz.Controllers
{
    public class MakeupTypeController
    {
        public static Response<List<MakeupType>> getAllMakeupType()
        {
            Response<List<MakeupType>> response = MakeupTypeHandler.getAllMakeupType();
            return response;
        }

        public static Response<List<string>> getAllMakeupTypeName()
        {
            Response<List<string>> response = MakeupTypeHandler.getAllMakeupTypeName();
            return response;
        }

        public static Response<MakeupType> insertNewMakeupType(string name)
        {
            Response<MakeupType> response = MakeupTypeHandler.insertNewMakeupType(name);
            return response;
        }

        public static Response<MakeupType> updateMakeupType(int id, string name)
        {
            Response<MakeupType> response = MakeupTypeHandler.updateMakeupType(id, name);
            return response;
        }

        public static Response<MakeupType> deleteMakeupType(int id)
        {
            Response<MakeupType> response = MakeupTypeHandler.deleteMakeupType(id);
            return response;
        }

        public static Response<MakeupType> newMakeupTypeValidation(string name)
        {
            if (name == null)
            {
                return Response<MakeupType>.createResponse("Name must be filled!", false, null);
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                return Response<MakeupType>.createResponse("Name length must be 1-99!", false, null);
            }

            return Response<MakeupType>.createResponse("Validation makeup type success!", true, null);
        }

        public static Response<MakeupType> getMakeupTypeByName(string name)
        {
            Response<MakeupType> response = MakeupTypeHandler.getMakeupTypeByName(name);
            return response;
        }
        public static Response<MakeupType> getMakeupTypeById(int id)
        {
            Response<MakeupType> response = MakeupTypeHandler.getMakeupTypeById(id);
            return response;
        }
    }
}