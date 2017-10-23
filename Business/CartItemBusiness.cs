using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// CartItemBusiness business component.
    /// </summary>
    public class CartItemBusiness
    {
        CartItemData db = new CartItemData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<CartItem> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartItem GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public CartItem Create(CartItem cartItem)
        {
            return db.Create(cartItem);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="cartItem"></param>
        public void Edit(CartItem cartItem)
        {
            db.UpdateById(cartItem);
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            db.DeleteById(id);
        }
    }
}
