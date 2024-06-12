using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader createTransactionHeader(int transactionId, int userId, DateTime date, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader() 
            { 
                TransactionID = transactionId,
                UserID = userId,
                TransactionDate = date,
                Status = status
            };
            return transactionHeader;
        }

        public static TransactionDetail createTransactionDetail(int transactiondetailId, int transactionId, int makeupId, int makeupQuantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionDetailID = transactiondetailId,
                TransactionID = transactionId,
                MakeupID = makeupId,
                Quantity = makeupQuantity
            };
            return transactionDetail;
        }
    }
}