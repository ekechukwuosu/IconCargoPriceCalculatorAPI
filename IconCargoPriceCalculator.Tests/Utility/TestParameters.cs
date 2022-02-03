using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconCargoPriceCalculator.Tests.Utility
{
    public class TestParameters
    {
        public static InputRequest GetSamplePriceRequest()
        {
            var request = new InputRequest
            {
                Width = 10,
                Height = 10,
                Depth = 15,
                Weight = 15,

            };
            return request;
        }
        public static CalculatorResponse GetSampleCalculatedResponse()
        {
            var response = new CalculatorResponse
            {
                CalculatedDimension = 1500,
                CalculatedPrice = 19.50m
            };
            return response;
        }
    }
}
