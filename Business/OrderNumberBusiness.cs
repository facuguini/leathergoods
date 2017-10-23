using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// OrderNumberBusiness business component.
    /// </summary>
    public class OrderNumberBusiness
    {
        OrderNumberData db = new OrderNumberData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderNumber GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public OrderNumber Create(OrderNumber orderNumber)
        {
            return db.Create(orderNumber);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="orderNumber"></param>
        public void Edit(OrderNumber orderNumber)
        {
            db.UpdateById(orderNumber);
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
