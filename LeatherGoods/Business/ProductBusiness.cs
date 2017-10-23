using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// ProductBusiness business component.
    /// </summary>
    public class ProductBusiness
    {
        ProductData db = new ProductData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            return db.Create(product);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="product"></param>
        public void Edit(Product product)
        {
            db.UpdateById(product);
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
