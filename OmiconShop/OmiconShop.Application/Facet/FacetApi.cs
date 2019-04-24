using OmiconShop.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Facet
{
    public class FacetApi
    {
        IProductRepository productRepository;

        public FacetApi(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<string> GetAllProductFacets()
        {
            return productRepository.GetAllProducts().Select(p => p.Type).Distinct().OrderBy(x => x);
        }
    }
}
