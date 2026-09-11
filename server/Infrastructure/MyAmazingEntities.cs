using LinqToDB.Mapping;

namespace Infrastructure;

public class MyAmazingEntities
{
    [PrimaryKey] public string Id { get; set; }
    public string MyProperty { get; set; }
}