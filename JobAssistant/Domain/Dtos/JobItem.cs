using JobAssistant.Domain.Enums;

namespace JobAssistant.Domain.Dtos;

public record JobItem(string Name, decimal Price, TaxType Tax)
{
    public bool IsExempted()
        => Tax == TaxType.Free;
}
