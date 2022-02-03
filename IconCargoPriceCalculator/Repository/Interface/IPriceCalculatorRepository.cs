using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;

namespace IconCargoPriceCalculator.Repository.Interface
{
    public interface IPriceCalculatorRepository
    {
        Task<CalculatorResponse> CalculateAndAdd(InputRequest inputRequest );
    }
}
