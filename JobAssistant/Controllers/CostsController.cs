using JobAssistant.Extensions;
using JobAssistant.QueryExecutors.GetCosts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace JobAssistant.Controllers
{
    [ApiController]
    [Route("calculation")]
    public class CostsController : ControllerBase
    {
        private readonly GetCostsQuery _getCostsQuery;

        public CostsController(GetCostsQuery getCostsQuery)
        {
            _getCostsQuery = getCostsQuery;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(GetCostsQueryResponseDto))]
        [SwaggerRequestExample(typeof(GetCostsQueryRequestDto), typeof(GetCostsQueryRequestDtoExample))]
        public IActionResult GetCosts(GetCostsQueryRequestDto dto)
            => _getCostsQuery.Execute(dto).ToActionResult();
    }
}