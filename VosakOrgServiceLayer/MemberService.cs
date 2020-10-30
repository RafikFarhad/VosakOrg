using System;
using System.Collections.Generic;
using System.Text;
using VosakOrgDataAccessLayer;
using VosakOrgRepositoryLayer;

namespace VosakOrgServiceLayer
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _memberRepository;

        public MemberService(IRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<Member> GetAllMemeber()
        {
            return _memberRepository.GetAll();
        }

        public Member GetMember(int Id)
        {
            return _memberRepository.Get(Id);
        }
    }
}
