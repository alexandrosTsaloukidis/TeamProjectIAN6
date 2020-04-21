using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Area> GetAreas()
        {
            return _context.Areas.ToList();
        }

        public Area GetArea(string name)
        {
            return _context.Areas.SingleOrDefault(c => c.Name == name);
        }

        public void AddArea(Area area)
        {
            _context.Areas.Add(area);
        }
    }
}