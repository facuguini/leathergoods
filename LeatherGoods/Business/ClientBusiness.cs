using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    /// <summary>
    /// Client business component.
    /// </summary>
    public class ClientBusiness
    {
        ClientData db = new ClientData();

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Client> GetList()
        {
            var result = db.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client GetById(int id)
        {
            var result = db.SelectById(id);
            return result;
        }

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Create(Client client)
        {
            return db.Create(client);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="client"></param>
        public void Edit(Client client)
        {
            db.UpdateById(client);
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
