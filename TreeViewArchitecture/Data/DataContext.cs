using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TreeViewArchitecture.Models;

namespace TreeViewArchitecture.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NodeModel> Nodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NodeModel>()
        .HasMany(n => n.ChildNodes)
        .WithOne(n => n.ParentNode)
        .HasForeignKey(n => n.ParentNodeId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NodeModel>().HasData(
           new NodeModel { NodeId = 1, NodeName = "Node 1", ParentNodeId = 1, IsActive = true, StartDate = DateTime.Now },
           new NodeModel { NodeId = 2, NodeName = "Node 2", ParentNodeId = 2, IsActive = true, StartDate = DateTime.Now },
           new NodeModel { NodeId = 3, NodeName = "Node 3", ParentNodeId = 1, IsActive = false, StartDate = DateTime.Now }
       );
        }

    }
}
