using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface ICityRepository
    {
        Task<object> GetCity();
    }
}
