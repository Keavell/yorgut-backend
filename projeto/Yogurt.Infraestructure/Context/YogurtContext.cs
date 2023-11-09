using Microsoft.EntityFrameworkCore;
using Yogurt.Domain.Entities;
using Yogurt.Domain.Entities.ReplyComment;
using Yogurt.Domain.Entities.User;

namespace Yogurt.Infraestructure.Context
{
    public class YogurtContext : DbContext
    {
        public YogurtContext(DbContextOptions options) : base(options) { }

        public DbSet<PublicacaoEntity> Publicacao { get; set; }
        public DbSet<UserEntity> Usuario { get; set; }
        public DbSet<CommentEntity> Comentarios { get; set; }
        public DbSet<ReplyCommentEntity> Resposta { get; set; }
        public DbSet<FileEntity> Arquivo { get; set; }
        public DbSet<CommunityEntity> Comunidade { get; set; }
        public DbSet<ProfileUserEntity> Perfil { get; set; }
        public DbSet<CityEntity> Cidade { get; set; }
        public DbSet<StatesEntity> Estado { get; set; }
        public DbSet<FriendEntity> Amizade { get; set; }
        public DbSet<ConnectEntity> Conectar { get; set; }
        public DbSet<ConnectivityEntity> Conectividade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}