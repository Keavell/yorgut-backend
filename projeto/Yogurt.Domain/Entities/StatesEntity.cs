using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yogurt.Domain.Entities
{
    public class StatesEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual ICollection<CityEntity> Cidades { get; set; }
    }
}
