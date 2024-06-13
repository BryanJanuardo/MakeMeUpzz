using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
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
        private static int generateNewTransactionId()
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

            return newId;
        }
        private static int generateNewTransactionDetailId()
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

            return newId;
        }
        public static bool checkoutCart(int userId)
        {
            List<Cart> carts = CartRepository.getAllCartsByUserId(userId);
            if (carts.Count() == 0)
                return false;

            TransactionHeader transactionHeader = TransactionFactory.createTransactionHeader(generateNewTransactionId(), userId, DateTime.Now, "Unhandled");
            TransactionRepository.insertTransactionHeaders(transactionHeader);

            foreach (Cart cart in carts)
            {
                int transactionId = transactionHeader.TransactionID;
                int makeupId = cart.MakeupID;
                int quantity = cart.Quantity;
                TransactionDetail td = TransactionFactory.createTransactionDetail(generateNewTransactionDetailId(), transactionId, makeupId, quantity);
                TransactionRepository.insertTransactionDetails(td);
            }
            CartRepository.emptyCartByUserId(userId);
            return true;
        }

        public static TransactionHeader getAllTransactionByUserID(int userID)
        {
            return TransactionRepository.getAllTransactionByUserID(userID);
        }

        public static List<TransactionHeader> getAllTransactionHeader()
        {
            return TransactionRepository.getAllTransactionHeaders();
        }

        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            return TransactionRepository.getAllUnhandledTransaction();
        }
       
        public static TransactionHeader getTransactionHeaderByID(int id)
        {
            return TransactionRepository.GetTransactionHeaderByID(id);
        }
        
        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            TransactionRepository.updateStatus(transactionHeader);
            return new Response<TransactionHeader>
            {
                Message = "Success",
                IsSuccess = true,
                payload = transactionHeader
            };
        }

        public static List<object> showDetail(int transactionID)
        {
            return TransactionRepository.showDetail(transactionID);
        }
    }
}