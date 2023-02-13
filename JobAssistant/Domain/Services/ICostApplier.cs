using JobAssistant.Domain.Entities;

namespace JobAssistant.Domain.Services;

/// <summary>
/// Changes additional total cost charge
/// </summary>
public interface ICostApplier
{
    decimal Apply(List<JobItem> items, CostAdjustingDto dto);
}
