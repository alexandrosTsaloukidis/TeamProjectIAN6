using System.Collections.Generic;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public interface IAreaRepository
    {
        List<Area> GetAreas();

        Area GetArea(string name);

        void AddArea(Area area);
    }
}