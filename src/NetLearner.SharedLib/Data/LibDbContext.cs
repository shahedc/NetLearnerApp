using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetLearner.SharedLib.Data
{
    public class LibDbContext: IdentityDbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options)
               : base(options)
        {
        }

        protected LibDbContext()
        {

        }

        public DbSet<LearningResource> LearningResources { get; set; }
        public DbSet<ResourceList> ResourceLists { get; set; }
    }
}
