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
    }
}