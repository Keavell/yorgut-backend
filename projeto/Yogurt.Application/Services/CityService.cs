using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Interfaces;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository repository)
        {
            _cityRepository = repository;
        }

        public async Task<object> GetAll()
        {
            var result = await _cityRepository.GetCity();
                
           return result;
        }
    }
}
