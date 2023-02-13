using FluentAssertions;
using JobAssistant.Domain.Dtos;
using JobAssistant.Domain.Enums;
using JobAssistant.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace JobAssistant.Tests.Domain.Services
{
    [TestClass]
    public class CostCalculatorTests
    {
        [TestMethod]
        public void GetCosts_Works()
        {
            var sut = GetSut();
            var jobItems = GetJobItems().ToList();

            var result = sut.GetCosts(jobItems, MarginType.Extra);

            result.TotalCost.Should().Be(2940.30m);
            result.Items.Should()
                        .SatisfyRespectively(
                                i => i.Cost.Should().Be(556.4m),
                                i => i.Cost.Should().Be(1983.37m));
        }

        private CostCalculator GetSut()
        {
            var marginOptions = new MarginOptions()
            {
                BaseMarginPercentage = 11,
                ExtraMarginPercentage = 16
            };

            var taxOptions = new TaxOptions() { Percentage = 7 };

            return new CostCalculator(
                new ICostApplier[]
                {
                    new MarginApplier(Options.Create(marginOptions))
                },
                new ICostAdjuster[]
                {
                    new TaxAdjuster(Options.Create(taxOptions))
                }
            );
        }

        private IEnumerable<JobItem> GetJobItems()
        {
            yield return new JobItem("envelopes", 520m, TaxType.Base);
            yield return new JobItem("letterhead", 1983.37m, TaxType.Free);
        }
    }
}
