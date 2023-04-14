using Microsoft.EntityFrameworkCore;
using BFF.Models.Entities;
using BFF.Core.Repository;

namespace BFF.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
