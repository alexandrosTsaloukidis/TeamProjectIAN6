using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.SingleOrDefault(c => c.Name == name);
        }

        public void AddCategory( Category category)
        {
            _context.Categories.Add(category);
        }
    }
}