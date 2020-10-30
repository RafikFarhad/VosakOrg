using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VosakOrg.Models;

namespace VosakOrg.Data
{
    public class VosakDBContext : DbContext
    {
        public DbSet<Member> Member{ get; set; }

        public VosakDBContext(DbContextOptions<VosakDBContext> options) : base(options)
        {
               
        }
    }

}
