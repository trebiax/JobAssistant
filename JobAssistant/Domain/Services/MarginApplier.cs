using JobAssistant.Domain.Dtos;
using JobAssistant.Domain.Enums;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace JobAssistant.Domain.Services;

public class MarginApplier : ICostApplier
{
    private readonly MarginOptions _options;

    public MarginApplier(IOptions<MarginOptions> options)
    {
        _options = options.Value;
    }

    public decimal Apply(List<JobItem> items, CostApplyingDto dto)
    {
        var percentage =
            dto.Margin == MarginType.Base
            ? _options.BaseMarginPercentage
            : _options.ExtraMarginPercentage;

        return items.Sum(i => i.Price) * percentage / 100;
    }
}

public class MarginOptions
{
    [Required]
    [Range(1, 100, ErrorMessage = "Base margin should be within 1-100")]
    public uint BaseMarginPercentage { get; set; }

    [Range(1, 100, ErrorMessage = "Extra margin should be within 1-100")]
    public uint ExtraMarginPercentage { get; set; }
}
