using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Modules;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class CartHandler
    {
        private static Response<int> generateNewCartId()
        {
            int newId = 1;
            int latestId = (from cart in CartRepository.getAllCart() select cart.CartID).ToList().LastOrDefault();

            if (latestId == 0)
            {
                newId = 1;
            }
            else
            {
                newId = latestId + 1;
            }

            return Response<int>.createResponse("Generate new Id success", true, newId);
        }

        public static Response<Cart> addMakeupToCart(int userId, int makeupId, int makeupQuantity)
        {
            Cart newCart = CartFactory.createCart(generateNewCartId().value, userId, makeupId, makeupQuantity);
            CartRepository.addMakeupToCart(newCart);

            return Response<Cart>.createResponse("Add cart success!", true, null);
        }

        public static Response<Cart> resetCart(int userId)
        {
            List<Cart> carts = CartRepository.getAllCartsByUserId(userId);
            if(carts.Count() == 0)
                return Response<Cart>.createResponse("Cart empty!", false, null);

            CartRepository.emptyCartByUserId(userId);

            return Response<Cart>.createResponse("Cart emptied success!", true, null);
        }
    }
}