﻿//====================================================================================================
// Base code generated with LeatherGoods - ASF.Business
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    /// <summary>
    /// Client business component.
    /// </summary>
    public class ClientBusiness
    {

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Add(Client client)
        {
            var clientDac = new ClientData();
            return clientDac.Create(client);
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var clientDac = new ClientData();
            clientDac.DeleteById(id);
        }

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<Client> All()
        {
            var clientDac = new ClientData();
            var result = clientDac.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client Find(int id)
        {
            var clientDac = new ClientData();
            var result = clientDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="client"></param>
        public void Edit(Client client)
        {
            var clientDac = new ClientData();
            clientDac.UpdateById(client);
        }

    }
}
