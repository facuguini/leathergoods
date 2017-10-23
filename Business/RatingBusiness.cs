using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// RatingBusiness business component.
    /// </summary>
    public class RatingBusiness
    {
        RatingData db = new RatingData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Rating> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rating GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public Rating Create(Rating rating)
        {
            return db.Create(rating);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="rating"></param>
        public void Edit(Rating rating)
        {
            db.UpdateById(rating);
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
