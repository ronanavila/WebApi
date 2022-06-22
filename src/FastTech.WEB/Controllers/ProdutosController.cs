using FastTech.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : MainController
{

    [HttpGet]
    public async Task<IActionResult> GetProdutosAsync()
    {
        return Ok();
    }
}