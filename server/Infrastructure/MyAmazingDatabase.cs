using LinqToDB;
using LinqToDB.Data;

namespace Infrastructure;

public class MyAmazingDatabase(DataOptions<MyAmazingDatabase> options) : DataConnection(options.Options)
{
    public ITable<MyAmazingEntities> MyAmazingEntities() => this.GetTable<MyAmazingEntities>();
}