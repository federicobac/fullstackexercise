using LinqToDB;
using LinqToDB.Data;

namespace Infrastructure;

public interface IMyAmazingDatabase
{
    ITable<MyAmazingEntities> MyAmazingEntities();
}

public class MyAmazingDatabase(DataOptions<MyAmazingDatabase> options) : DataConnection(options.Options), IMyAmazingDatabase
{
    public ITable<MyAmazingEntities> MyAmazingEntities() => this.GetTable<MyAmazingEntities>();
}