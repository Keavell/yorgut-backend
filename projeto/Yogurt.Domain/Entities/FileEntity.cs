using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities
{
    public class FileEntity : EntityBase
    {
        public Guid IdPublicacao { get; set; }

        public Byte[] Conteudo { get; set; }

        public string MimeType { get; set; }

        public DateTime DataCriacao { get; set; }

        [ForeignKey("IdPublicacao")]
        public virtual PublicacaoEntity publicacao { get; set; }

        public FileEntity(Guid idPublicacao, byte[] conteudo, string mimeType, DateTime dataCriacao)
        {
            IdPublicacao = idPublicacao;
            Conteudo = conteudo;
            MimeType = mimeType;
            DataCriacao = dataCriacao;
        }
    }
}
