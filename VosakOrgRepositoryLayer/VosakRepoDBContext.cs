using Microsoft.EntityFrameworkCore;
using VosakOrgDataAccessLayer;

namespace VosakOrgRepositoryLayer
{
    public class VosakRepoDBContext : DbContext
    {

        public VosakRepoDBContext(DbContextOptions<VosakRepoDBContext> options) : base(options)
        {
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new MemberMap(modelBuilder.Entity<Member>());
            new PostMap(modelBuilder.Entity<Post>());
        }
    }

}
