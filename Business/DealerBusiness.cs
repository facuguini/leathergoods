using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// DealerBusiness business component.
    /// </summary>
    public class DealerBusiness
    {
        DealerData db = new DealerData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Dealer> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dealer GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public Dealer Create(Dealer dealer)
        {
            return db.Create(dealer);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="dealer"></param>
        public void Edit(Dealer dealer)
        {
            db.UpdateById(dealer);
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
