using Startersite.Models;
using Startersite.Models.ModelViews;

namespace Startersite.IManagers
{
    public interface IOrderProcessor
    {
        Order ProcessOrder(BasketModel basket, OrderInformation orderInformation);
    }
}