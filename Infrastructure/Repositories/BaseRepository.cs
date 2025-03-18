using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BaseRepository
{
    public DatabaseContext Context { get; }

    public BaseRepository(DatabaseContext context)
    {
        Context = context;
    }
}