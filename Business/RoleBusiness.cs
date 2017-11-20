using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Framework.Cache;

namespace Business
{
    /// <summary>
    /// RoleBusiness business component.
    /// </summary>
    public class RoleBusiness
    {
        RoleData db = new RoleData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Role> GetList()
        {
            var list = (List<Role>)Cache.Get("Roles");
            if(list == null) {
                list = db.Select();
                Cache.Add("Roles", list);
            }
            return list;
        }

        /// <summary>
        /// FindAll by user method.
        /// </summary>
        /// <returns></returns>
        public List<Role> GetByUserId(int id)
        {
            return db.SelectByUserId(id);
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetById(int id)
        {
            var list = (List<Role>)Cache.Get("Roles");
            if(list == null) {
                list = db.Select();
                Cache.Add("Roles", list);
            }
            return list.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Role Create(Role Role)
        {
            Cache.Remove("Roles");
            return db.Create(Role);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="Role"></param>
        public void Edit(Role cart)
        {
            Cache.Remove("Roles");
            db.UpdateById(cart);
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Cache.Remove("Roles");
            db.DeleteById(id);
        }
    }
}
