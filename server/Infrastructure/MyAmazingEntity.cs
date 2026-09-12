using LinqToDB.Mapping;

namespace Infrastructure;

public class MyAmazingEntity
{
    [PrimaryKey] public string Id { get; set; }
    public string EntityName { get; set; }
}