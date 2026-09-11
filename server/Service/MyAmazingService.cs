using Infrastructure;

namespace Service;

public class MyAmazingService(MyAmazingDatabase db)
{
    public List<MyAmazingEntities> GetEntities()
    {
        return db.MyAmazingEntities().ToList();
    }
}