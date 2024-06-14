using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services.Description;

namespace MakeMeUpzz.Handlers
{
    public class TransactionHandler
    {
        private static Response<int> generateNewTransactionId()
        {
            int newId = 1;
            int latestId = (from th in TransactionRepository.getAllTransactionHeaders() select th.TransactionID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return Response<int>.createResponse("Generate new id success!", true, newId);
        }
        private static Response<int> generateNewTransactionDetailId()
        {
            int newId = 1;
            int latestId = (from td in TransactionRepository.getAllTransactionDetail() select td.TransactionDetailID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return Response<int>.createResponse("Generate new id success!", true, newId);
        }
        public static Response<Cart> checkoutCart(int userId)
        {
            List<Cart> carts = CartRepository.getAllCartsByUserId(userId);
            if (carts.Count() == 0)
                return Response<Cart>.createResponse("Cart is empty!", false, null);

            TransactionHeader transactionHeader = TransactionFactory.createTransactionHeader(generateNewTransactionId().value, userId, DateTime.Now, "Unhandled");
            TransactionRepository.insertTransactionHeaders(transactionHeader);

            foreach (Cart cart in carts)
            {
                int transactionId = transactionHeader.TransactionID;
                int makeupId = cart.MakeupID;
                int quantity = cart.Quantity;
                TransactionDetail td = TransactionFactory.createTransactionDetail(generateNewTransactionDetailId().value, transactionId, makeupId, quantity);
                TransactionRepository.insertTransactionDetails(td);
            }

            CartRepository.emptyCartByUserId(userId);
            return Response<Cart>.createResponse("Checkout cart success!", true, null);
        }

        public static Response<List<TransactionHeader>> getAllTransactionByUserID(int userID)
        {
            List<TransactionHeader> thList = TransactionRepository.getAllTransactionByUserID(userID);
            return Response<List<TransactionHeader>>.createResponse("Get all transaction by user id success!", true, thList);
        }

        public static Response<List<TransactionHeader>> getAllTransactionHeader()
        {
            List<TransactionHeader> thList = TransactionRepository.getAllTransactionHeaders();
            return Response<List<TransactionHeader>>.createResponse("Get all transaction success!", true, thList);
        }

        public static Response<List<TransactionHeader>> getAllUnhandledTransaction()
        {
            List<TransactionHeader> thList = TransactionRepository.getAllUnhandledTransaction();
            return Response<List<TransactionHeader>>.createResponse("Get all unhandled transaction success!", true, thList);
        }
       
        public static Response<TransactionHeader> getTransactionHeaderByID(int id)
        {
            TransactionHeader th = TransactionRepository.GetTransactionHeaderByID(id);
            return Response<TransactionHeader>.createResponse("Get transaction by id success!", true, th);
        }
        
        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            TransactionRepository.updateStatus(transactionHeader);
            return Response<TransactionHeader>.createResponse("Update status transaction success!", true, transactionHeader);
        }

        public static Response<List<object>> showDetail(int transactionID)
        {
            var transactionDetail = TransactionRepository.showDetail(transactionID);
            return Response<List<object>>.createResponse("Show transaction detail success!", true, transactionDetail);
        }

        public static void HandleTransaction(int transactionID)
        {
            TransactionRepository.HandleTransaction(transactionID);
        }

    }
}