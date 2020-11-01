using System.Collections.Generic;
using VosakOrgDataAccessLayer;

namespace VosakOrgServiceLayer
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMemeber();

        Member GetMember(int Id);
    }
}
