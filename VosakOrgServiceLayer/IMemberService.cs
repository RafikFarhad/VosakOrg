using System.Collections.Generic;
using VosakOrgDataAccessLayer;

namespace VosakOrgServiceLayer
{
    public interface IPostService
    {
        IEnumerable<Member> GetAllMemeber();

        Member GetMember(int Id);
    }
}
