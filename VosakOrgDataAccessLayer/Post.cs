using System;
using System.Collections.Generic;
using System.Text;

namespace VosakOrgDataAccessLayer
{
    public class Post : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
    }
}
