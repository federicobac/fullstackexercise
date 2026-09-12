using LinqToDB;
using LinqToDB.Data;

namespace Infrastructure;

public interface IMyAmazingDatabase
{
    ITable<MyAmazingEntity> MyAmazingEntities();
}

public class MyAmazingDatabase(DataOptions<MyAmazingDatabase> options) : DataConnection(options.Options), IMyAmazingDatabase
{
    public ITable<MyAmazingEntity> MyAmazingEntities() => this.GetTable<MyAmazingEntity>();
}