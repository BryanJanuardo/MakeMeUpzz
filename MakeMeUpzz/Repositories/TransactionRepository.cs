using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class TransactionRepository
    {
        public static TransactionHeader getLastTransaction()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.TransactionHeaders.ToList().LastOrDefault();
        }
        public static List<TransactionHeader> getAllTransactionByUserID(int userID)
        {
            DatabaseContextEntities db = Singleton.getDB();
            List<TransactionHeader> header = (from th in db.TransactionHeaders where th.UserID == userID select th).ToList();
            return header;
        }
        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.TransactionHeaders.ToList();
        }

        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.TransactionHeaders.ToList().FindAll(x => x.Status.Equals("Unhandled"));
        }
        public static TransactionHeader GetTransactionHeaderByID(int id)
        {
            DatabaseContextEntities db = Singleton.getDB();
            TransactionHeader header = db.TransactionHeaders.Find(id);
            return header;
        }
        public static void updateStatus(TransactionHeader transactionHeader)
        {
            DatabaseContextEntities db = Singleton.getDB();
            transactionHeader.Status = "Handled";
            db.SaveChanges();
        }

        public static List<Object> showDetail(int transactionID)
        {
            DatabaseContextEntities db = Singleton.getDB();
            var td = (from x in db.TransactionDetails
                      join Makeup in db.Makeups on x.MakeupID equals Makeup.MakeupID
                      join MakeupBrand in db.MakeupBrands on Makeup.MakeupBrandID equals MakeupBrand.MakeupBrandID
                      join MakeupType in db.MakeupTypes on Makeup.MakeupTypeID equals MakeupType.MakeupTypeID
                      where x.TransactionID == transactionID
                      select new
                      {
                          transactionID = x.TransactionID,
                          MakeupID = Makeup.MakeupID,
                          MakeupName = Makeup.MakeupName,
                          MakeupPrice = Makeup.MakeupPrice,
                          MakeupWeight = Makeup.MakeupWeight,
                          MakeupTypeName = MakeupType.MakeupTypeName,
                          MakeupBrandName = MakeupBrand.MakeupBrandName,
                          Quantity = x.Quantity,
                          Total = x.Quantity * Makeup.MakeupPrice
                      }).ToList<object>();
            return td;
        }
        public static void insertTransactionHeaders(TransactionHeader th)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public static List<TransactionDetail> getAllTransactionDetail()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.TransactionDetails.ToList();
        }
        public static void insertTransactionDetails(TransactionDetail td)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public static void HandleTransaction(int TransactionID)
        {
            DatabaseContextEntities db = Singleton.getDB();
            TransactionHeader updateTransaction = GetTransactionHeaderByID(TransactionID);
            updateTransaction.Status = "handled";
            db.SaveChanges();
        }
    }
}