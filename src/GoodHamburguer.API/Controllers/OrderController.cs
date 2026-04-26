using GoodHamburguer.Application.UseCases;
using GoodHamburguer.Communication.Requests.Order;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            [FromServices] ICreateOrderUseCase useCase,
            [FromBody] RequestCreateOrder request) 
        {
            var response = await useCase.Execute(request);

        return Created();
        }
    }
}