using BFF.API.Core.Service;
using BFF.API.Helpers;
using BFF.Core.Data;
using BFF.Models.Entities;
using BFF.Repositories;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository,MapHelper mapper) : base(repository, mapper)
        {
        }
    }
}
