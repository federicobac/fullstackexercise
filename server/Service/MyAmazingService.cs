using Infrastructure;

namespace Service;

public interface IMyAmazingService
{
    List<MyAmazingEntities> GetEntities();
}

public class MyAmazingService(MyAmazingDatabase db) : IMyAmazingService
{
    public List<MyAmazingEntities> GetEntities()
    {
        return db.MyAmazingEntities().ToList();
    }
}