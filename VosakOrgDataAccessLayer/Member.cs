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

        public BloodGroup BloodGroup { get; set; }

        public int Order { get; set; } = 0;

        [AllowNull]
        public string Address { get; set; }

        [AllowNull]
        public DateTime JoinedAt { get; set; }

        [AllowNull]
        public DateTime DateOfBirth{ get; set; }

        public virtual Post Post { get; set; }
    }
}
