using BFF.Core.Data;
using BFF.Core.Repository;
using BFF.Models.Entities;

namespace BFF.Repositories
{
    public class ProductRepository : ODataRepository<Product>,IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}
