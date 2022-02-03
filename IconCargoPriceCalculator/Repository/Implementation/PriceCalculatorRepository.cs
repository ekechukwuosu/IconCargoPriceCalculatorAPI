using AutoMapper;
using IconCargoPriceCalculator.DB;
using IconCargoPriceCalculator.Helpers;
using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;
using IconCargoPriceCalculator.Repository.Interface;

namespace IconCargoPriceCalculator.Repository.Implementation
{
    public class PriceCalculatorRepository : IPriceCalculatorRepository
    {
        private readonly AppDBContext _appDBContext;
        private readonly ILogger<PriceCalculatorRepository> _logger;
        private readonly CalculationEngine _calculationEngine;
        private readonly IMapper _mapper;
        public PriceCalculatorRepository(AppDBContext appDBContext, ILogger<PriceCalculatorRepository> logger, CalculationEngine calculationEngine, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _logger = logger;
            _calculationEngine = calculationEngine;
            _mapper = mapper;
        }
        public async Task<CalculatorResponse> CalculateAndAdd(InputRequest inputRequest)
        {
            
            CalculatorResponse response = new CalculatorResponse();
            try
            {
                //Price calculation using logic rules
                var calculatedResponse = _calculationEngine.CalculatePrice(inputRequest);

                //input request mapping to entity model
                var _mapped = _mapper.Map<PriceRequest>(inputRequest);
                _mapped.CalculatedDimension = calculatedResponse.CalculatedDimension;
                _mapped.CalculatedPrice = calculatedResponse.CalculatedPrice;
                
                //Persisiting input and calculations for future review
                await _appDBContext.PriceRequests.AddAsync(_mapped);
                _appDBContext.SaveChanges();

                //Response mapping from entity model
                response  = _mapper.Map<CalculatorResponse>(_mapped);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in PriceCalculatorRepository class, CalculateAndAdd Method. Message : {ex.Message}");
            }
            return response;
        }
    }
}
