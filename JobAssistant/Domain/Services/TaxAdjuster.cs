using JobAssistant.Domain.Dtos;
using Microsoft.Extensions.Options;

namespace JobAssistant.Domain.Services;

public class TaxAdjuster : ICostAdjuster
{
    private readonly TaxOptions _options;

    public TaxAdjuster(IOptions<TaxOptions> options)
    {
        _options = options.Value;
    }

    public decimal Adjust(JobItem jobItem)
    {
        if (jobItem.IsExempted())
        {
            return 0;
        }

        return jobItem.Price * _options.Percentage / 100;
    }
}

public record TaxOptions
{
    public uint Percentage { get; set; }
}

