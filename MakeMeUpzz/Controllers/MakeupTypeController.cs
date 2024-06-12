using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupTypeController
    {
        public static List<string> getAllMakeupTypeName()
        {
            List<string> makeupTypeNames = (from type in MakeupTypeHandler.getAllMakeupType() select type.MakeupTypeName).ToList();
            return makeupTypeNames;
        }

        public static void insertNewMakeupType(string name)
        {
            MakeupTypeHandler.insertNewMakeupType(name);
        }

        public static void updateMakeupType(int id, string name)
        {
            MakeupTypeHandler.updateMakeupType(id, name);
        }

        public static string newMakeupTypeValidation(string name)
        {
            if (name == null)
            {
                return "Name must be filled!";
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                return "Name length must be 1-99!";
            }

            return "";
        }
    }
}