using OmiconShop.Domain.Entities;
using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startersite.IManagers
{
    public interface IProductRepositoryы
    {
        IEnumerable<Product> Products { get; }
    }
}
