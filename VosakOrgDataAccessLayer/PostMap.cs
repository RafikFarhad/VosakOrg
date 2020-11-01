using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VosakOrgDataAccessLayer
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(post => post.Id);
            entityTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(20);
            entityTypeBuilder.HasMany(post => post.Members)
                .WithOne(member => member.Post)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
