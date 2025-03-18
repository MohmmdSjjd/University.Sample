using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class Factory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer(connectionString: "Server=.;Database=UniversityManagement;TrustServerCertificate=True;Trusted_Connection=True;");

        return new DatabaseContext(optionsBuilder.Options);
    }
}