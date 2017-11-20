using System;
using System.Collections.Generic;
using Data;
using Entities;
using Framework.Crypto;

namespace Business
{
    /// <summary>
    /// UserBusiness business component.
    /// </summary>
    public class UserBusiness
    {
        UserData db = new UserData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<User> GetList()
        {
            return db.Select();
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return db.SelectById(id);
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User LogIn(User user)
        {
            var list = db.SelectByUserName(user.UserName);
            if(list.Count == 0)
                throw new Exception("Wrong username");
            var _user = list[0];
            if(user.PasswordHash != Crypto.Decrypt(_user.PasswordHash))
                throw new Exception("Incorrect password");
            _user.Roles = GetUserRole(_user.Id);
            return _user;
        }

        /// <summary>
        /// Find user roles.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<Role> GetUserRole(int id)
        {
            return new RoleBusiness().GetByUserId(id);
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public User Create(User User)
        {
            return db.Create(User);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="User"></param>
        public void Edit(User cart)
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
