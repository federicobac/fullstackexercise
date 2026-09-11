using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

public class MyAmazingController : ControllerBase
{
    private readonly IMyAmazingService _myAmazingService;
    
    [HttpGet(nameof(GetEntities))]
    public List<MyAmazingEntities> GetEntities()
    {
        return service.GetEntities();
    }
    
}