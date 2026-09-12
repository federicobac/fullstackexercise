using Infrastructure;
using LinqToDB;

namespace Service;

public interface IMyAmazingService
{
    public List<MyAmazingEntity> GetEntities();
    public void CreateEntity();
    public void UpdateEntity();
    public int DeleteEntity();
}

public class MyAmazingService : IMyAmazingService
{
    private readonly MyAmazingDatabase _db;

    public MyAmazingService(MyAmazingDatabase db)
    {
        _db = db;
        Console.WriteLine("Service instantiated");
    }
    public List<MyAmazingEntity> GetEntities()
    {
        return _db.MyAmazingEntities().ToList();
    }

    public void CreateEntity()
    {
        var entity = new MyAmazingEntity()
        {
            Id = new Random().Next(),
            EntityName = "My amazing entity"
        };
        
        _db.Insert(entity);
    }

    public void UpdateEntity()
    {
        throw new NotImplementedException();
    }

    public int DeleteEntity()
    {
        throw new NotImplementedException();
    }
}