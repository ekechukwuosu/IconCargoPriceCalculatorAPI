using AutoMapper;
using IconCargoPriceCalculator.Helpers;
using IconCargoPriceCalculator.Mappings.Profiles;
using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;
using IconCargoPriceCalculator.Repository.Implementation;
using IconCargoPriceCalculator.Repository.Interface;
using IconCargoPriceCalculator.Tests.Utility;
using IconCargoPriceCalculator.Tests.Utility.FakeDBContexts;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace IconCargoPriceCalculator.Tests.Repository
{
    public class PriceCalculatorRepositoryShould
    {
        private readonly PriceCalculatorRepository _PriceCalculatorRepository;
        private static IMapper _mapper;
        public PriceCalculatorRepositoryShould()
        {
            var _appDBContext = new Mock<FakeDBContext>();
            var _logger = new Mock<ILogger<PriceCalculatorRepository>>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new PriceRequestProfile());
                    mc.AddProfile(new CalculatedResponseProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            var _loggerCalculatorEngine = new Mock<ILogger<CalculationEngine>>();
            var _calculationEngine = new CalculationEngine(_loggerCalculatorEngine.Object);
            _PriceCalculatorRepository = new PriceCalculatorRepository(_appDBContext.Object.GetDatabaseContext().Result, _logger.Object, _calculationEngine, _mapper);
        }
        [Fact]
        public async void CalculateAndAdd_Success()
        {
            var result = await _PriceCalculatorRepository.CalculateAndAdd(TestParameters.GetSamplePriceRequest());

            Assert.NotNull(result);
            Assert.IsAssignableFrom<CalculatorResponse>(result);
        }
        [Fact]
        public async void CalculateAndAdd_ResponseEquals()
        {
            var result = await _PriceCalculatorRepository.CalculateAndAdd(TestParameters.GetSamplePriceRequest());

            Assert.NotNull(result);
            Assert.Equal(result.CalculatedDimension, TestParameters.GetSampleCalculatedResponse().CalculatedDimension);
            Assert.Equal(result.CalculatedPrice, TestParameters.GetSampleCalculatedResponse().CalculatedPrice);
        }
    }
}
