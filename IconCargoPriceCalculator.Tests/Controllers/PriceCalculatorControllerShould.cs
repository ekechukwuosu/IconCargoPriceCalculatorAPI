using IconCargoPriceCalculator.Controllers;
using IconCargoPriceCalculator.Models;
using IconCargoPriceCalculator.Models.Request;
using IconCargoPriceCalculator.Repository.Interface;
using IconCargoPriceCalculator.Tests.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IconCargoPriceCalculator.Tests.Controllers
{
    public class PriceCalculatorControllerShould
    {
        private readonly PriceCalculatorController _controller;
        public PriceCalculatorControllerShould()
        {
            var _mockIPriceCalculatorRepository = new Mock<IPriceCalculatorRepository>();
            _mockIPriceCalculatorRepository.Setup(p => p.CalculateAndAdd(It.IsAny<InputRequest>())).ReturnsAsync(new CalculatorResponse());
             _controller = new PriceCalculatorController(_mockIPriceCalculatorRepository.Object);
        }

        [Fact]
        public void Should_return_price_calculator_BadRequest()
        {
            var request = new InputRequest();
            var result = _controller.Post(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }
        [Fact]
        public void Should_return_price_calculator_Success()
        {
            var request = TestParameters.GetSamplePriceRequest();
            var result = _controller.Post(request);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
        [Fact]
        public void Should_return_price_calculator_TestAuthourizeAttribute()
        {
            var result = _controller.GetType().GetMethod("Post").GetCustomAttributes(typeof(AuthorizeAttribute), true);

            Assert.Equal(typeof(AuthorizeAttribute), result[0].GetType());//Ensure [Authorize] Attribute exist

        }

    }
}
