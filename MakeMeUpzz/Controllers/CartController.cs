using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class CartController
    {
        public static bool quantityValidation(int quantity)
        {
            if (quantity <= 0)
                return false;
            return true;
        }

        public static void addMakeupToCart(int userId, int makeupId, int makeupQuantity)
        {
            CartHandler.addMakeupToCart(userId, makeupId, makeupQuantity);
        }

        public static string resetCart(int userId)
        {
            if (!CartHandler.resetCart(userId))
            {
                return "Cart already empty";
            }

            return "Reset Cart Successfully!";
        }
    }
}