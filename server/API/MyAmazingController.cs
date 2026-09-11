using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[ApiController]
public class MyAmazingController(IMyAmazingService service) : ControllerBase
{
    [HttpGet(nameof(GetEntities))]
    public List<MyAmazingEntities> GetEntities()
    {
        return service.GetEntities();
    }
    
}