using GoodHamburguer.Application.UseCases.Order.Create;
using GoodHamburguer.Application.UseCases.Order.Delete;
using GoodHamburguer.Application.UseCases.Order.Get;
using GoodHamburguer.Application.UseCases.Order.GetAll;
using GoodHamburguer.Application.UseCases.Order.Update;
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
            [FromBody] RequestOrder request) 
        {
            var response = await useCase.Execute(request);

            return Created("", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(
            [FromServices] IUpdateOrderUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestOrder request)
        {
            await useCase.Execute(id, request);

            return NoContent();
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

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(
            [FromServices] IGetAllOrderUseCase useCase)
        {
            var response = await useCase.Execute();

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}