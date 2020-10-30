using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VosakOrg.Models
{
    public class Member
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Post { get; set; } = "Member";

        [AllowNull]
        [MaxLength(100)]
        public string Address { get; set; }

        [AllowNull]
        public DateTime JoinedAt { get; set; }
    }
}
