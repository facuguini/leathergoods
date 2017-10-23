using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// OrderDetailBusiness business component.
    /// </summary>
    public class OrderDetailBusiness
    {
        OrderDetailData db = new OrderDetailData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDetail GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public OrderDetail Create(OrderDetail orderDetail)
        {
            return db.Create(orderDetail);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="orderDetail"></param>
        public void Edit(OrderDetail orderDetail)
        {
            db.UpdateById(orderDetail);
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
