using Xunit;
using FakeItEasy;
using FluentAssertions;
using HotDrinkDistributor.Domain.Ports;
using HotDrinkDistributor.Domain.Models;
using HotDrinkDistributor.Infrastructure.Services;

namespace HotDrinkDistributor.Tests.HotDrinkServiceTests
{
    // Test class for GetRecipe method
    public class GetRecipeTests
    {
        private readonly IHotDrinkService _hotDrinkService;
        private readonly IHotDrinkRepository _hotDrinkRepository;

        public GetRecipeTests()
        {
            _hotDrinkRepository = A.Fake<IHotDrinkRepository>();
            _hotDrinkService = new HotDrinkService(_hotDrinkRepository);
        }

        [Fact]
        public void GetRecipe_WithValidId_ReturnsRecipe()
        {
            // Arrange
            int validId = 1;
            var expectedRecipe = new Recipe { Id = validId, Name = "TestRecipe" };
            A.CallTo(() => _hotDrinkRepository.GetRecipe(validId)).Returns(expectedRecipe);

            // Act
            var result = _hotDrinkService.GetRecipe(validId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedRecipe);
        }

        [Fact]
        public void GetRecipe_WithInvalidId_ThrowsException()
        {
            // Arrange
            int invalidId = 999;
            A.CallTo(() => _hotDrinkRepository.GetRecipe(invalidId)).Returns((Recipe)null);

            // Act & Assert
            _hotDrinkService.Invoking(s => s.GetRecipe(invalidId))
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Recipe Not Found");
        }
    }
}
