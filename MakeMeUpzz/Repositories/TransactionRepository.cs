using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class TransactionRepository
    {
        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.TransactionHeaders.ToList();
        }

        public static void insertTransactionHeaders(TransactionHeader th)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public static void insertTransactionDetails(TransactionDetail td)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }
    }
}