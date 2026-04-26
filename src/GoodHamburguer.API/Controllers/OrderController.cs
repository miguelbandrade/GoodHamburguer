using GoodHamburguer.Application.UseCases.Order.Create;
using GoodHamburguer.Application.UseCases.Order.Delete;
using GoodHamburguer.Application.UseCases.Order.Get;
using GoodHamburguer.Communication.Requests.Order;
using Microsoft.AspNetCore.Http.HttpResults;
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

            return Created("", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(
            [FromServices] IDeleteOrderUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(
            [FromServices] IGetOrderUseCase useCase,
            [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}