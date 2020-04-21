using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Core.Repositories
{
    public interface ILifeInfoRepository
    {
        void AddLifeInfo(LifeInfo lifeInfo);
    }
}
