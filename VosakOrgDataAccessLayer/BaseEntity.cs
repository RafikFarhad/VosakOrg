using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VosakOrgDataAccessLayer
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 101)]
        public DateTime CreatedAt { get; set; }

        [Column(Order = 102)]
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }
    }
}
