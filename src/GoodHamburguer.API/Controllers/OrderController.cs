using GoodHamburguer.Application.UseCases.Order.Create;
using GoodHamburguer.Application.UseCases.Order.Delete;
using GoodHamburguer.Application.UseCases.Order.Get;
using GoodHamburguer.Application.UseCases.Order.GetAll;
using GoodHamburguer.Application.UseCases.Order.Update;
using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;
using GoodHamburguer.Communication.Responses.Order;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Cria um novo pedido na hamburgueria.
        /// </summary>
        /// <param name="useCase">Caso de uso para criação.</param>
        /// <param name="request">Dados do pedido.</param>
        /// <returns>ID do pedido criado.</returns>
        /// <response code="201">Pedido criado com sucesso.</response>
        /// <response code="400">Dados inválidos ou produtos não encontrados.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreated), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder(
            [FromServices] ICreateOrderUseCase useCase,
            [FromBody] RequestOrder request) 
        {
            var response = await useCase.Execute(request);

            return Created("", response);
        }

        /// <summary>
        /// Atualiza as informações de um pedido existente.
        /// </summary>
        /// <param name="useCase">Caso de uso para atualização.</param>
        /// <param name="id">ID do pedido.</param>
        /// <param name="request">Novos dados do pedido.</param>
        /// <response code="204">Pedido atualizado com sucesso.</response>
        /// <response code="400">Dados inválidos ou produtos não encontrados.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrder(
            [FromServices] IUpdateOrderUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestOrder request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        /// <summary>
        /// Remove um pedido do sistema.
        /// </summary>
        /// <param name="useCase">Caso de uso para exclusão.</param>
        /// <param name="id">ID do pedido.</param>
        /// <response code="204">Pedido removido com sucesso.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder(
            [FromServices] IDeleteOrderUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        /// <summary>
        /// Obtém os detalhes completos de um pedido específico.
        /// </summary>
        /// <param name="useCase">Caso de uso para busca.</param>
        /// <param name="id">ID do pedido.</param>
        /// <returns>Detalhes do pedido.</returns>
        /// <response code="200">Pedido encontrado com sucesso.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrder(
            [FromServices] IGetOrderUseCase useCase,
            [FromRoute] int id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        /// <summary>
        /// Lista todos os pedidos cadastrados (versão resumida).
        /// </summary>
        /// <param name="useCase">Caso de uso para listagem.</param>
        /// <returns>Lista de pedidos.</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="204">Nenhum pedido encontrado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseShortOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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