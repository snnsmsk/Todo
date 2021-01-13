using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.DbContexts.ModelConfiguration
{
    class ComputedColumnSqlConfiguration : IComputedColumnSqlConfiguration
    {
        public void CreateComputedProperties(ModelBuilder builder)
        {
            foreach (var entity in typeof(ToDoDbContext).GetProperties())
            {
                if (entity.PropertyType.IsGenericType)
                {
                    Type type = Type.GetType(entity.PropertyType.GenericTypeArguments[0].FullName);

                    foreach (var propertyInfo in Type.GetType(entity.PropertyType.GenericTypeArguments[0].FullName).GetProperties())
                        if (propertyInfo.Name.Equals("CreationDate"))
                        {
                            builder.Entity(type).Property("CreationDate")
                            .HasDefaultValueSql("GETDATE()");

                        }
                        else if (propertyInfo.Name.Equals("Deleted"))
                        {
                            builder.Entity(type).Property("Deleted")
                            .HasDefaultValue(false);
                        }
                        else if (propertyInfo.Name.Equals("CreatedByUserId"))
                        {
                            builder.Entity(type).Property("CreatedByUserId")
                            .HasDefaultValue(SystemConstant.DefaultUserId);
                        }
                }
            }
        }
    }
}