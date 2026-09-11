using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

public class MyAmazingController(MyAmazingService service)
{
    [HttpGet(nameof(GetEntities))]
    public List<MyAmazingEntities> GetEntities()
    {
        return service.GetEntities();
    }
    
}