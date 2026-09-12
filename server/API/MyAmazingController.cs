using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[ApiController]
public class MyAmazingController : ControllerBase
{
    private readonly IMyAmazingService _service;
    public MyAmazingController(IMyAmazingService service)
    {
        _service = service;
        Console.WriteLine("Controller has been instantiated");
    }
    
    [HttpGet(nameof(GetEntities))]
    public List<MyAmazingEntity> GetEntities()
    {
        return _service.GetEntities();
    }
    
    [HttpPost(nameof(CreateEntity))]
    public void CreateEntity()
    {
        _service.CreateEntity();
    }
    
    [HttpPut(nameof(UpdateEntity))]
    public void UpdateEntity()
    {
        _service.UpdateEntity();
    }
    
    [HttpDelete(nameof(DeleteEntity))]
    public int DeleteEntity()
    {
        _service.DeleteEntity();
    }
}