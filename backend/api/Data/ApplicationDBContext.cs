using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        // tạo 1 constructor
        
        public ApplicationDBContext(DbContextOptions dbContextOptions)

        : base(dbContextOptions)
        {
            
        }
        public DbSet<Member> Members{get;set;}
        public DbSet<Note> Notes { get; set; }
    }
}