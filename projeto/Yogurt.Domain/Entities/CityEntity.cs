using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yogurt.Domain.Entities
{
    public class CityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public virtual StatesEntity Estado { get; set; }

        public virtual ICollection<ProfileUserEntity> Perfis { get; set; }
    }
}
