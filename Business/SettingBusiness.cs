using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// SettingBusiness business component.
    /// </summary>
    public class SettingBusiness
    {
        SettingData db = new SettingData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Setting> GetList()
        {
            return db.Select();
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Setting GetById(int id)
        {
            return db.SelectById(id);
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public Setting Create(Setting setting)
        {
            return db.Create(setting);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="setting"></param>
        public void Edit(Setting cart)
        {
            db.UpdateById(cart);
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
