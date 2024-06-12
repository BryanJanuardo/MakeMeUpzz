using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                TransactionDetail td = TransactionFactory.createTransactionDetail(transactionId, makeupId, quantity);
                TransactionRepository.insertTransactionDetails(td);
            }
            CartRepository.emptyCartByUserId(userId);
            return true;
        }
    }
}