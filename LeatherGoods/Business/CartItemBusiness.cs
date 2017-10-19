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
    /// CartItemBusiness business component.
    /// </summary>
    public class CartItemBusiness
    {

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public CartItem Add(CartItem cartItem)
        {
            var cartItemDac = new CartItemData();
            return cartItemDac.Create(cartItem);
        }

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var cartItemDac = new CartItemData();
            cartItemDac.DeleteById(id);
        }

        /// <summary>
        /// FindAll method.
        /// </summary>
        /// <returns></returns>
        public List<CartItem> All()
        {
            var cartItemDac = new CartItemData();
            var result = cartItemDac.Select();
            return result;
        }

        /// <summary>
        /// Find method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartItem Find(int id)
        {
            var cartItemDac = new CartItemData();
            var result = cartItemDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="cartItem"></param>
        public void Edit(CartItem cartItem)
        {
            var cartItemDac = new CartItemData();
            cartItemDac.UpdateById(cartItem);
        }

    }
}
