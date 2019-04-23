using System;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Admin.ViewModel
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public PagingInfoViewModel PagingInfo { get; set; }

        public OrderStatuses? SelectedStatus { get; set; }
    }
}