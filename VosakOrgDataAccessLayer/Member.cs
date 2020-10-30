using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VosakOrgDataAccessLayer
{
    public enum BloodGroup
    {
        APositive, ANegative, BPositive, BNegative, ABPositive, ABNegative, OPositive, ONegative

    }
    public class Member : BaseEntity
    {

        public string Name { get; set; }

        public virtual Post Post { get; set; }

        public BloodGroup BloodGroup { get; set; }

        [AllowNull]
        public string Address { get; set; }

        [AllowNull]
        public DateTime JoinedAt { get; set; }
    }
}
