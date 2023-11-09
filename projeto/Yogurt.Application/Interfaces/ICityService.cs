using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;

namespace Yogurt.Application.Interfaces
{
    public interface ICityService
    {
        Task<object> GetAll();
    }
}
