using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SistemaDeBilheteira.Services.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Controller1 : Controller
{
    private List<int> Number { get; set; } = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

    // GET
    public ActionResult<List<int>> Index()
    {
        return Ok(Number);
    }
}
