using JobAssistant.Domain.Dtos;
using JobAssistant.Domain.Enums;

namespace JobAssistant.QueryExecutors.GetCosts;

public record GetCostsQueryRequestDto(MarginType Margin, List<JobItem> Items);