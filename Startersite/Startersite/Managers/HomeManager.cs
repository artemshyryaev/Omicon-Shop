﻿using OmiconShop.Domain.Entities;
using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class HomeManager
    {
        public Product GetProductById(int orderId)
        {
            return SqlQueries.GetProductById(orderId);
        }
    }
}