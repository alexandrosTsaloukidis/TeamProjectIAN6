using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Repositories;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence
{
    public class LifeInfoRepository : ILifeInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public LifeInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddLifeInfo(LifeInfo lifeInfo)
        {
            _context.LifeInfos.Add(lifeInfo);
        }
    }
}