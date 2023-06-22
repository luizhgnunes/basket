using AutoFixture;
using Basket.BusinessLogic;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Interfaces.Repository;
using Basket.Common.Models;
using Moq;

namespace Basket.UnitTests.BusinessLogic
{
    public class BasketBusinessLogicTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IBasketRepository> _basketRepository;
        private readonly Mock<IProductBusinessLogic> _productBusinessLogic;

        private BasketBusinessLogic _sut;

        public BasketBusinessLogicTests() 
        {
            _fixture = new Fixture();
            _basketRepository = new Mock<IBasketRepository>();
            _productBusinessLogic = new Mock<IProductBusinessLogic>();
            _sut = new BasketBusinessLogic(_basketRepository.Object, _productBusinessLogic.Object);
        }

        [Fact]
        public async Task CreateBasketAsyncShouldCallAdd()
        {
            //Arrange
            var orderRequest = _fixture.Create<BasketRequest>();
            //Act
            await _sut.CreateBasketAsync(orderRequest);
            //Assert
            _basketRepository.Verify(r => r.Add(It.Is<Common.Models.Basket>(x => x.OrderRequest.UserEmail == orderRequest.UserEmail)));
        }
    }
}
