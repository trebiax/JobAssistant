using JobAssistant.Domain.Dtos;

namespace JobAssistant.Domain.Services;

/// <summary>
/// Adjusts (changes) each price of <see cref="JobItem"/>
/// </summary>
public interface ICostAdjuster
{
    decimal Adjust(JobItem jobItem);
}
