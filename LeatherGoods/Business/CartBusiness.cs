using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// CartBusiness business component.
    /// </summary>
    public class CartBusiness
    {
        CartData db = new CartData();
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart Create(Cart cart)
        {
            return db.Create(cart);
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            db.DeleteById(id);
        }

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Cart> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="cart"></param>
        public void Edit(Cart cart)
        {
            db.UpdateById(cart);
        }

    }
}
