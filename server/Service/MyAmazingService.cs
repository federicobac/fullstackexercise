using System.ComponentModel.DataAnnotations;
using Infrastructure;
using LinqToDB;

namespace Service;

public interface IMyAmazingService
{
    public List<MyAmazingEntity> GetEntities();
    public MyAmazingEntity CreateEntity(MyAmazingEntity entity);
    public MyAmazingEntity? UpdateEntity(int id, MyAmazingEntity entity);
    public bool DeleteEntity(int id);
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
        // 1. Construct IQueryable
        var entities = _db.MyAmazingEntities().AsQueryable();

        // 2. Execute query
        return entities.ToList();
    }

    public MyAmazingEntity CreateEntity(MyAmazingEntity entity)
    {
        //1. Validation rules
        if (string.IsNullOrEmpty(entity.EntityName))
        {
            throw new ValidationException(
                "Entity name cannot be empty");
        }

        //2.Execute query
        entity.Id = _db.InsertWithInt32Identity(entity);
        return entity;
    }

    public MyAmazingEntity? UpdateEntity(int id, MyAmazingEntity entity)
    {
        // 1. Construct IQueryable
        var entities = _db.MyAmazingEntities().AsQueryable();

        // 2. Find the entity
        var existingEntity = entities
            .FirstOrDefault(g => g.Id == id);

        if (existingEntity == null) 
            throw new ValidationException(
                "Entity with that id was not found");

        // 3. Change the entity
        existingEntity.EntityName = entity.EntityName;

        // 4. Update DB
        _db.Update(existingEntity);

        return existingEntity;
    }

    public bool DeleteEntity(int id)
    {
        // 1. Construct IQueryable
        var entities = _db.MyAmazingEntities().AsQueryable();

        // 2. Find the entity
        var existingEntity = entities
            .FirstOrDefault(g => g.Id == id);

        if (existingEntity == null)
            throw new ValidationException(
                "Entity with that id was not found");

        // 3. Delete the entity
        _db.Delete(existingEntity);

        return true;
    }
}