using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VosakOrgDataAccessLayer
{
    public class MemberMap
    {
        public MemberMap(EntityTypeBuilder<Member> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(member => member.Id);
            entityTypeBuilder.Property(member => member.Name).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(member => member.Address).IsRequired().HasMaxLength(50);
            entityTypeBuilder.HasOne(member => member.Post)
                .WithMany(post => post.Members)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
