using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Infraestructure.Repositories
{
    public class CityRepository: ICityRepository
    {
        private readonly YogurtContext _yogurtContext;

        public YogurtContext YogurtContext => _yogurtContext;

        public CityRepository(YogurtContext yogurtContext)
        {
            _yogurtContext = yogurtContext;
        }
        //teste de join para mostrar.
        public async Task<object> GetCity()
        {
           var query = (from f in _yogurtContext.Cidade
                        join s in _yogurtContext.Estado
                        on f.IdEstado equals s.Id
                        select new
                        {
                            Id = f.Id,
                            Nome = f.Nome,
                            Estado = s.Nome
                        }).Take(5);


            return query;
        }
    }
}
