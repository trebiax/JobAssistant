using JobAssistant.Domain.Enums;

namespace JobAssistant.Domain.Entities;

public record JobItem(string Name, decimal Price, TaxType Tax)
{
    public bool IsExempted()
        => Tax == TaxType.Free;
}
