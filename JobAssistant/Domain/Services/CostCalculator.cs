using JobAssistant.Domain.Dtos;
using JobAssistant.Domain.Enums;
using JobAssistant.Extensions;

namespace JobAssistant.Domain.Services;

public class CostCalculator
{
    private readonly IEnumerable<ICostApplier> _appliers;
    private readonly IEnumerable<ICostAdjuster> _adjusters;

    public CostCalculator(
        IEnumerable<ICostApplier> appliers,
        IEnumerable<ICostAdjuster> adjusters)
    {
        _appliers = appliers;
        _adjusters = adjusters;
    }
    public (decimal TotalCost, List<JobItemCost> Items) GetCosts(
        List<JobItem> items,
        MarginType margin)
    {
        var dto = new CostApplyingDto(margin);

        var costItems = items.Select(item =>
        {
            var adjustedSum = _adjusters
                                .Select(adj => adj.Adjust(item))
                                .Sum();

            var cost = item.Price + adjustedSum;

            return new JobItemCost(item.Name, cost.RoundToClosestCent());
        }).ToList();

        var costItemsSum = costItems.Sum(i => i.Cost);
        var appliedCharge = _appliers.Sum(a => a.Apply(items, dto));

        var totalCost = costItemsSum + appliedCharge;

        return (totalCost.RoundToEvenCent(), costItems);
    }
}