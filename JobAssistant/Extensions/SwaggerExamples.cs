using JobAssistant.Domain.Dtos;
using JobAssistant.Domain.Enums;
using JobAssistant.QueryExecutors.GetCosts;
using Swashbuckle.AspNetCore.Filters;

namespace JobAssistant.Extensions;

public class GetCostsQueryRequestDtoExample : IExamplesProvider<GetCostsQueryRequestDto>
{
    public GetCostsQueryRequestDto GetExamples()
    {
        return new GetCostsQueryRequestDto(MarginType.Extra, new List<JobItem>
        {
            new JobItem("envelopes", 520m, TaxType.Base),
            new JobItem("letterhead", 1983.37m, TaxType.Free)
        });
    }
}
