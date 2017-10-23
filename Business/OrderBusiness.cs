using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// OrderBusiness business component.
    /// </summary>
    public class OrderBusiness
    {
        OrderData db = new OrderData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Order> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order Create(Order order)
        {
            return db.Create(order);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="order"></param>
        public void Edit(Order order)
        {
            db.UpdateById(order);
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
