using OmiconShop.Application.Admin.Operations;
using OmiconShop.Application.Basket.Operations;
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
        BasketOperations basketOperations;

        public CheckoutApi(IOrderRepository orderRepository, EmailSender emailSender,
            OrderOperations orderOperations, BasketOperations basketOperations)
        {
            this.orderRepository = orderRepository;
            this.emailSender = emailSender;
            this.orderOperations = orderOperations;
            this.basketOperations = basketOperations;
        }

        public void DeclineOrder(int orderId)
        {
            Task.Run(() => orderRepository.DeleteOrderAsync(orderId));
        }

        public async Task<Order> SubmitOrder(BasketViewModel basket, int orderId)
        {
            if (basket != null)
                basket.ClearBasket();

            var order = orderRepository.GetOrderById(orderId);
            await emailSender.SendOrderConfirmationEmail(order);

            return order;
        }
        public Order ProcessOrder(BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            var t = orderRepository.AddOrderAsync((order) =>
             {
                 orderOperations.AddUserInformationToOrder(ref order, orderInformation);
                 orderOperations.AddOrderInformationToOrder(ref order, basket, orderInformation);
                 orderOperations.AddBasketLinesToOrder(basket, ref order);
             });
            t.Wait();

            return t.Result;
        }

        public BasketViewModel GetCurrentBasket()
        {
            return basketOperations.GetBasket();
        }
    }
}
