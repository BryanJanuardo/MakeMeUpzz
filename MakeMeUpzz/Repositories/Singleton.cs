using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class Singleton
    {
        private static DatabaseContextEntities db;
        public static DatabaseContextEntities getDB()
        {
            if(db == null)
            {
                db = new DatabaseContextEntities();
            }

            return db;
        }
    }
}