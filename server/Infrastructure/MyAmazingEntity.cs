using LinqToDB.Mapping;

namespace Infrastructure;

public class MyAmazingEntity
{
    [PrimaryKey] public int Id { get; set; }
    public string EntityName { get; set; }
}