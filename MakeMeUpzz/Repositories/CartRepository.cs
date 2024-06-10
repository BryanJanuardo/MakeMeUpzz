using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class CartRepository
    {
        public static List<Cart> getAllCart()
        {
            DatabaseContextEntities db = Singleton.getDB();
            return db.Carts.ToList();
        }
        public static void addMakeupToCart(Cart newCart)
        {
            DatabaseContextEntities db = Singleton.getDB();
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public static List<Cart> getAllCartsByUserId(int userId) 
        {
            DatabaseContextEntities db = Singleton.getDB();
            List<Cart> carts = (from cart in db.Carts where cart.UserID == userId select cart).ToList();
            return carts;
        }

        public static void emptyCartByUserId(int userId)
        {
            DatabaseContextEntities db = Singleton.getDB();
            List<Cart> carts = getAllCartsByUserId(userId);

            foreach (Cart cart in carts)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }
    }
}