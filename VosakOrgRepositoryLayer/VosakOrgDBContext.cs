using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using VosakOrgDataAccessLayer;

namespace VosakOrgRepositoryLayer
{
    public class VosakOrgDBContext : DbContext
    {

        public VosakOrgDBContext(DbContextOptions<VosakOrgDBContext> options) : base(options)
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
