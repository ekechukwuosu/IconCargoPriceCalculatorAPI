using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;

namespace IconCargoPriceCalculator.Helpers
{
    public class CalculationEngine
    {
        private readonly ILogger<CalculationEngine> _logger;
        public CalculationEngine(ILogger<CalculationEngine> logger)
        {
            _logger = logger;
        }
        public CalculatorResponse CalculatePrice(InputRequest inputRequeset)
        {
            CalculatorResponse response = new CalculatorResponse();
            List<decimal> priceList = new List<decimal>();
            
            try
            {
                var dimensions = inputRequeset.Height * inputRequeset.Width * inputRequeset.Depth;
              
                if(dimensions <= 2000 && inputRequeset.Weight <= 20)
                {
                    //for Cargo4you
                    priceList.Add( Cargo4You(dimensions, inputRequeset.Weight).CalculatedPrice);
                }
                if(dimensions <= 1700 && (inputRequeset.Weight > 10 && inputRequeset.Weight <= 30))
                {
                    //for Shipfaster
                    priceList.Add(ShipFaster(dimensions, inputRequeset.Weight).CalculatedPrice);
                }
                if(dimensions >= 500 && inputRequeset.Weight >= 10)
                {
                    //for MaltaShip
                    priceList.Add(MaltaShip(dimensions, inputRequeset.Weight).CalculatedPrice); 
                }
                response.CalculatedDimension = dimensions;
                response.CalculatedPrice = priceList.Min();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CalculationEngine class, CalculatePrice Method. Message : {ex.Message}");
            }
            return response;
        }
        public CalculatorResponse Cargo4You (double dimensions, double weight)
        {
            decimal dimensionPrice = 0m, weightPrice = 0m;
            var response = new CalculatorResponse();
            try
            {
                //Calculate price by dimension
                if (dimensions <= 1000)
                {
                    dimensionPrice = 10m;
                }
                else if (dimensions > 1000 && dimensions <= 2000)
                {
                    dimensionPrice = 20m;
                }
                //Calculate price by weight
                if (weight <= 2)
                {
                    weightPrice = 15m;
                }
                else if (weight > 2 && weight <= 15)
                {
                    weightPrice = 18m;
                }
                else if (weight > 15 && weight <= 20)
                {
                    weightPrice = 35m;
                }
                response.CalculatedDimension = dimensions;
                response.CalculatedPrice = Math.Max(dimensionPrice, weightPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CalculationEngine class, Cargo4You Method. Message : {ex.Message}");
            }
            return response;
        }
        public CalculatorResponse ShipFaster(double dimensions, double weight)
        {
            decimal dimensionPrice = 0m, weightPrice = 0m;
            var response = new CalculatorResponse();
            try
            {
                //Calculate price by dimension
                if (dimensions <= 1000)
                {
                    dimensionPrice = 11.99m;
                }
                else if (dimensions > 1000 && dimensions <= 1700)
                {
                    dimensionPrice = 21.99m;
                }
                //Calculate price by weight
                if (weight > 10 && weight <= 15)
                {
                    weightPrice = 16.50m;
                }
                else if (weight > 15 && weight <= 25)
                {
                    weightPrice = 36.50m;
                }
                else if (weight > 25)
                {
                    weightPrice = 40 + (Convert.ToDecimal(weight - 25) * 0.417m);
                }
                response.CalculatedDimension = dimensions;
                response.CalculatedPrice = Math.Max(dimensionPrice, weightPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CalculationEngine class, ShipFaster Method. Message : {ex.Message}");
            }
            
            return response;
        }
        public CalculatorResponse MaltaShip(double dimensions, double weight)
        {
            decimal dimensionPrice = 0m, weightPrice = 0m;
            var response = new CalculatorResponse();
            try
            {
                //Calculate price by dimension
                if (dimensions <= 1000)
                {
                    dimensionPrice = 9.50m;
                }
                else if (dimensions > 1000 && dimensions <= 2000)
                {
                    dimensionPrice = 19.50m;
                }
                else if (dimensions > 2000 && dimensions <= 5000)
                {
                    dimensionPrice = 48.50m;
                }
                else if (dimensions > 5000)
                {
                    dimensionPrice = 147.50m;
                }
                //Calculate price by weight
                if (weight > 10 && weight <= 20)
                {
                    weightPrice = 16.99m;
                }
                else if (weight > 20 && weight <= 30)
                {
                    weightPrice = 33.99m;
                }
                else if (weight > 30)
                {
                    weightPrice = 43.99m + (Convert.ToDecimal(weight - 25) * 0.41m);
                }
                response.CalculatedDimension = dimensions;
                response.CalculatedPrice = Math.Max(dimensionPrice, weightPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CalculationEngine class, MaltaShip Method. Message : {ex.Message}");
            }
            
            return response;
        }
    }
}
