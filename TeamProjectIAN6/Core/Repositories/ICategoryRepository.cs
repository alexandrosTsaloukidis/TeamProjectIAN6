using System.Collections.Generic;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategory(string name);

        void AddCategory(Category category);
    }
}