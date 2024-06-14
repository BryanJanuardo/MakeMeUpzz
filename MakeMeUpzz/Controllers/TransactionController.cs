using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class TransactionController
    {
        public static Response<Cart> checkoutCart(int userId)
        {
            Response<Cart> response = TransactionHandler.checkoutCart(userId);
            return response;
        }

        public static Response<List<TransactionHeader>> getAllTransactionHeaders()
        {
            Response<List<TransactionHeader>> response = TransactionHandler.getAllTransactionHeader();
            return response;
        }

        public static Response<List<TransactionHeader>> getAllTransactionByUserID(int userId)
        {
            Response<List<TransactionHeader>> response = TransactionHandler.getAllTransactionByUserID(userId);
            return response;
        }

        public static Response<List<TransactionHeader>> getAllUnhandledTransaction()
        {
            Response<List<TransactionHeader>> response = TransactionHandler.getAllUnhandledTransaction();
            return response;
        }

        public static Response<TransactionHeader> getTransactionHeaderByID(int id)
        {
            Response<TransactionHeader> response = TransactionHandler.getTransactionHeaderByID(id);
            return response;
        }

        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            Response<TransactionHeader> response = TransactionHandler.updateStatus(transactionHeader);
            return response;
        }

        public static Response<List<object>> showDetail(int transactionID)
        {
            Response<List<object>> response = TransactionHandler.showDetail(transactionID);
            return response;
        }

        public static Response<TransactionHeader> HandleTransaction(int transactionID)
        {
            Response<TransactionHeader> response = TransactionHandler.HandleTransaction(transactionID);
            return response;
        }
    }
}