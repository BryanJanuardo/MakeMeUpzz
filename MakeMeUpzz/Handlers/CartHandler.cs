using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class CartHandler
    {
        private static int generateNewMakeupId()
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

            return newId;
        }

        public static void addMakeupToCart(int userId, int makeupId, int makeupQuantity)
        {
            Cart newCart = CartFactory.createCart(generateNewMakeupId(), userId, makeupId, makeupQuantity);
            CartRepository.addMakeupToCart(newCart);
        }

        public static bool resetCart(int userId)
        {
            List<Cart> carts = CartRepository.getAllCartsByUserId(userId);
            if(carts.Count() == 0)
                return false;

            CartRepository.emptyCartByUserId(userId);
            return true;
        }
    }
}