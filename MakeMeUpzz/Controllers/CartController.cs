using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class CartController
    {
        public static Response<Cart> quantityValidation(int quantity)
        {
            
            if (quantity <= 0)
                return Response<Cart>.createResponse("Quantity must more than 0!", false, null);
            return Response<Cart>.createResponse("Input Validated", true, null);
        }

        public static Response<Cart> addMakeupToCart(int userId, int makeupId, int makeupQuantity)
        {
            Response<Cart> response = CartHandler.addMakeupToCart(userId, makeupId, makeupQuantity);
            return response;
        }

        public static Response<Cart> resetCart(int userId)
        {
            Response<Cart> response = CartHandler.resetCart(userId);
            return response;
        }
    }
}