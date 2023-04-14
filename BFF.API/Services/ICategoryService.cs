using BFF.API.Core.Service;
using BFF.Core.Data;
using BFF.Models.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
    }
}
