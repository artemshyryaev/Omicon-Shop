using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startersite
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> Orders { get; }
    }
}
