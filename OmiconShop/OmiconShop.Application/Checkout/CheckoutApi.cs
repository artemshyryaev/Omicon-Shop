using OmiconShop.Application.Admin.Operations;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout.Operations;
using OmiconShop.Application.Checkout.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderOperations = OmiconShop.Application.Checkout.Operations.OrderOperations;

namespace OmiconShop.Application.Checkout
{
    public class CheckoutApi
    {
        IOrderRepository orderRepository;
        OrderOperations orderOperations;
        EmailSender emailSender;

        public CheckoutApi(IOrderRepository orderRepository, EmailSender emailSender, OrderOperations orderOperations)
        {
            this.orderRepository = orderRepository;
            this.emailSender = emailSender;
            this.orderOperations = orderOperations;
        }

        public void DeclineOrder(int orderId)
        {
            Task.Run(() => orderRepository.DeleteOrderAsync(orderId));
        }

        public Order SubmitOrder(BasketViewModel basket, int orderId)
        {
            if (basket != null)
                basket.ClearBasket();

            var order = orderRepository.GetOrderById(orderId);
            emailSender.SendOrderConfirmationEmail(order);

            return order;
        }
        public Order ProcessOrder(BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            Order order = new Order();

            Task.Run(() => orderRepository.AddOrderAsync(order, () =>
            {
                orderOperations.AddUserInformationToOrder(ref order, orderInformation);
                orderOperations.AddOrderInformationToOrder(ref order, basket, orderInformation);
                orderOperations.AddBasketLinesToOrder(basket, ref order);
            }));

            return order;
        }
    }
}
