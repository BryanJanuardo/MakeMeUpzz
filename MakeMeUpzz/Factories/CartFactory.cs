using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class CartFactory
    {
        public static Cart createCart(int cartId, int userId, int makeupId, int makeupQuantity)
        {
            Cart newCart = new Cart()
            {
                CartID = cartId,
                UserID = userId,
                MakeupID = makeupId,
                Quantity = makeupQuantity
            };
            return newCart;
        }
    }
}