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
        public DbSet<ContentFeed> ContentFeeds { get; set; }
        public DbSet<TopicTag> TopicTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            modelBuilder.Entity<LearningResourceTopicTag>()
                .HasKey(lrtt => new { lrtt.LearningResourceId, lrtt.TopicTagId });

            modelBuilder.Entity<LearningResourceTopicTag>()
                .HasOne(lrtt => lrtt.LearningResource)
                .WithMany(lr => lr.LearningResourceTopicTags)
                .HasForeignKey(lrtt => lrtt.LearningResourceId);

            modelBuilder.Entity<LearningResourceTopicTag>()
                .HasOne(lrtt => lrtt.TopicTag)
                .WithMany(tt => tt.LearningResourceTopicTags)
                .HasForeignKey(lrtt => lrtt.TopicTagId);
        }
    }
}
