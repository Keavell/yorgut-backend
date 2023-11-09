using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yogurt.Application.Utils
{
    public class StatusCodeEnum
    {
        public enum Return
        {
            Sucess = 200,
            BadRequest = 400,
            NotFound = 404
        }
    }
}
