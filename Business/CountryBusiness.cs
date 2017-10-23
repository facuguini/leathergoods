using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// CountryBusiness business component.
    /// </summary>
    public class CountryBusiness
    {
        CountryData db = new CountryData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Country> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public Country Create(Country country)
        {
            return db.Create(country);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="country"></param>
        public void Edit(Country country)
        {
            db.UpdateById(country);
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
