using JobAssistant.Domain.Dtos;

namespace JobAssistant.QueryExecutors.GetCosts;

public record GetCostsQueryResponseDto(decimal TotalCost, List<JobItemCost> Items);
