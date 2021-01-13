using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using ToDo.Data.DbContexts.ModelConfiguration;
using ToDo.Data.Model;
using ToDo.Data.ModelConfiguration;

namespace ToDo.Data.DbContexts
{
    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<DsToDo> ToDos { get; set; }

        public virtual void Commit()
        {
            using (IDbContextTransaction ts = Database.BeginTransaction())
            {
                try
                {
                    base.SaveChanges();
                    ts.Commit();
                }
                catch (Exception e)
                {
                    ts.Rollback();
                    throw e;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DsToDoEntityTypeConfiguration());

            if (Database.IsSqlServer())
            {
                new ComputedColumnSqlConfiguration().CreateComputedProperties(builder);
            }
        }
    }
}
