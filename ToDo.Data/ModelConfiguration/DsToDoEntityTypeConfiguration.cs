using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Data.Model;

namespace ToDo.Data.ModelConfiguration
{
    class DsToDoEntityTypeConfiguration : IEntityTypeConfiguration<DsToDo>
    {
        public void Configure(EntityTypeBuilder<DsToDo> builder)
        {
            builder.ToTable("DsToTo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.Title)
               .HasMaxLength(1000);

            builder.Property(p => p.Completed)
              .HasDefaultValue(false);
        }
    }
}