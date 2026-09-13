using System.ComponentModel.DataAnnotations;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class MyAmazingController : ControllerBase
{
    private readonly IMyAmazingService _service;

    public MyAmazingController(IMyAmazingService service)
    {
        _service = service;
        Console.WriteLine("Controller has been instantiated");
    }

    [HttpGet]
    public List<MyAmazingEntity> GetEntities()
    {
        return _service.GetEntities();
    }

    [HttpPost]
    public MyAmazingEntity CreateEntity(MyAmazingEntity entity)
    {
        return _service.CreateEntity(entity);
    }

    [HttpPut("{id}")]
    public ActionResult<MyAmazingEntity> UpdateEntity(
        int id,
        MyAmazingEntity entity)
    {
        if (id <= 0)
            throw new ValidationException("ID must be greater than 0");
        
        var updated = _service.UpdateEntity(id, entity);
        return updated;
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEntity(int id)
    {
        if (id <= 0)
            throw new ValidationException("ID must be greater than 0");
        
        var deleted = _service.DeleteEntity(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}