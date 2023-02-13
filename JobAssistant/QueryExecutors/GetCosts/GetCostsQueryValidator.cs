using FluentValidation;
using JobAssistant.Domain.Dtos;

namespace JobAssistant.QueryExecutors.GetCosts
{
    public class GetCostsQueryValidator : AbstractValidator<GetCostsQueryRequestDto>
    {
        public GetCostsQueryValidator()
        {
            RuleFor(dto => dto.Margin)
                .IsInEnum()
                .WithMessage("Selected margin type is not supported");

            RuleForEach(dto => dto.Items)
                .SetValidator(new JobItemValidator());
        }
    }

    public class JobItemValidator : AbstractValidator<JobItem>
    {
        public JobItemValidator()
        {
            RuleFor(i => i.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price of item must be greater or equal to 0");

            RuleFor(i => i.Tax)
                .IsInEnum()
                .WithMessage("Selected tax type is not supported");

            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Name of item shouldn't be empty");
        }
    }
}
