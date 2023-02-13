using JobAssistant.Extensions;
using JobAssistant.QueryExecutors.GetCosts;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Calculate(GetCostsQueryRequestDto dto)
            => _getCostsQuery.Execute(dto).ToActionResult();
    }
}