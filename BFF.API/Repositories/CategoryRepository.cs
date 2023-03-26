using BFF.Core.Data;
using BFF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BFF.Repositories
{
    public class CategoryRepository : ODataRepository<Category>,ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
            CheckCategories();

        }

        private async void CheckCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
        }
    }
}
