using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class TransactionController
    {
        public static string checkoutCart(int userId)
        {
            if(!TransactionHandler.checkoutCart(userId))
                return "Cart is empty!";

            return "Cart Has been Checkout!";
        }

        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            return TransactionHandler.getAllTransactionHeader();
        }

        public static List<TransactionHeader> getAllTransactionByUserID(int userId)
        {
            return TransactionHandler.getAllTransactionByUserID(userId);
        }

        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            return TransactionHandler.getAllUnhandledTransaction();
        }

        public static TransactionHeader getTransactionHeaderByID(int id)
        {
            return TransactionHandler.getTransactionHeaderByID(id);
        }

        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            Response<TransactionHeader> response = TransactionHandler.updateStatus(transactionHeader);
            return response;
        }

        public static List<object> showDetail(int transactionID)
        {
            return TransactionHandler.showDetail(transactionID);
        }
    }
}