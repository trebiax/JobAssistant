using CSharpFunctionalExtensions;
using JobAssistant.Domain.Services;
using JobAssistant.Extensions;

namespace JobAssistant.QueryExecutors.GetCosts;

public class GetCostsQuery
{
    private readonly CostCalculator _costCalculator;

    public GetCostsQuery(CostCalculator costCalculator)
    {
        _costCalculator = costCalculator;
    }

    public Result<GetCostsQueryResponseDto> Execute(GetCostsQueryRequestDto requestDto)
    {
        var validationResult = new GetCostsQueryValidator().ValidateToResult(requestDto);

        if (validationResult.IsFailure)
        {
            return Result.Failure<GetCostsQueryResponseDto>(validationResult.Error);
        }

        var costs = _costCalculator.GetCosts(requestDto.Items, requestDto.Margin);

        return Result.Success<GetCostsQueryResponseDto>(new(costs.TotalCost, costs.Items));
    }
}
