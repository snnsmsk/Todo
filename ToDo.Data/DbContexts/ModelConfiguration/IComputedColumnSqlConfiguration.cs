using Microsoft.EntityFrameworkCore;

namespace ToDo.Data.DbContexts.ModelConfiguration
{
    interface IComputedColumnSqlConfiguration
    {
        void CreateComputedProperties(ModelBuilder builder);
    }
}
