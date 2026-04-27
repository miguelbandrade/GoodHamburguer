using GoodHamburguer.Application.UseCases.Product.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Listagem do Cardápio.
        /// </summary>
        /// <param name="useCase">Listagem do Cardápio.</param>
        /// <returns>Lista de produtos.</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        /// <response code="204">Nenhum produto encontrado.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllProductUseCase useCase) 
        {
            var response = await useCase.Execute();

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }

    }
}
