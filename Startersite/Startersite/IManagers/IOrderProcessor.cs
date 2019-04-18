using OmiconShop.Domain.Entities;
using Startersite.Models.ViewModel;

namespace Startersite.IManagers
{
    public interface IOrderProcessor
    {
        Order ProcessOrder(BasketViewModel basket, OrderInformationViewModel orderInformation);
    }
}