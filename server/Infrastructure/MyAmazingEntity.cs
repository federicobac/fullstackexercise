using LinqToDB.Mapping;

namespace Infrastructure;

public class MyAmazingEntity
{
    [PrimaryKey, Identity] public int Id { get; set; }
    public string EntityName { get; set; }
}