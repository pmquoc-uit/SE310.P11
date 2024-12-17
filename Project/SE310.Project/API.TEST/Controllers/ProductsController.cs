using API.Controllers;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoFixture;

namespace API.TEST.Controllers
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private Mock<IUnitOfWork>? _mockUnitOfWork;
        private Mock<IPhotoService>? _mockPhotoService;
        private ProductsController? _controller;
        private Fixture? _fixture;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockPhotoService = new Mock<IPhotoService>();
            _controller = new ProductsController(_mockUnitOfWork.Object, _mockPhotoService.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task GetProducts_ShouldReturnPagedResult()
        {
            // Arrange
            var specParams = _fixture.Create<ProductSpecParams>();

            // Tạo danh sách sản phẩm giả
            var products = _fixture.CreateMany<Product>(2).ToList();

            // Mock repository trả về danh sách sản phẩm
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().ListAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(products);

            // Mock CountAsync trả về số lượng sản phẩm
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().CountAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(products.Count);

            // Act
            var result = await _controller!.GetProducts(specParams);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));

            var pagedResult = okResult?.Value as Pagination<Product>;
            Assert.That(pagedResult, Is.Not.Null);
            Assert.That(pagedResult?.Data.Count, Is.EqualTo(2));
            Assert.That(pagedResult?.Data[0].Name, Is.EqualTo(products[0].Name));
            Assert.That(pagedResult?.Data[1].Name, Is.EqualTo(products[1].Name));
        }

        [Test]
        public async Task GetProducts_ShouldReturnEmptyList_WhenNoProducts()
        {
            // Arrange
            var specParams = _fixture.Create<ProductSpecParams>();
            var products = new List<Product>();  // Danh sách sản phẩm rỗng

            // Mock repository trả về danh sách rỗng
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().ListAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(products);

            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().CountAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(0);

            // Act
            var result = await _controller!.GetProducts(specParams);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));

            var pagedResult = okResult?.Value as Pagination<Product>;
            Assert.That(pagedResult, Is.Not.Null);
            Assert.That(pagedResult?.Data.Count, Is.EqualTo(0));  // Kiểm tra số lượng sản phẩm trả về là 0
        }

        [Test]
        public async Task GetProducts_ShouldApplySearchFilter()
        {
            // Arrange
            var specParams = new ProductSpecParams
            {
                Search = "product 1"
            };

            var products = _fixture.CreateMany<Product>(3).ToList();
            var filteredProducts = products
                .Where(p =>
                    p.Name.Contains(specParams.Search, StringComparison.CurrentCultureIgnoreCase)).ToList();

            // Mock repository trả về sản phẩm đã lọc
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().ListAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(filteredProducts);
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().CountAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(filteredProducts.Count);

            // Act
            var result = await _controller!.GetProducts(specParams);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));

            var pagedResult = okResult?.Value as Pagination<Product>;
            Assert.That(pagedResult, Is.Not.Null);
            Assert.That(pagedResult?.Data.Count, Is.EqualTo(filteredProducts.Count));  // Kiểm tra kết quả lọc
        }

        [Test]
        public async Task GetProducts_ShouldApplySorting()
        {
            // Arrange
            var specParams = new ProductSpecParams
            {
                Sort = "Name"
            };

            var products = _fixture.CreateMany<Product>(3).ToList();
            var sortedProducts = products.OrderBy(p => p.Name).ToList();

            // Mock repository trả về sản phẩm đã sắp xếp
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().ListAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(sortedProducts);
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().CountAsync(It.IsAny<ProductSpecification>()))
                .ReturnsAsync(sortedProducts.Count);

            // Act
            var result = await _controller!.GetProducts(specParams);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));

            var pagedResult = okResult?.Value as Pagination<Product>;
            Assert.That(pagedResult, Is.Not.Null);
            Assert.That(pagedResult?.Data.First().Name, Is.EqualTo(sortedProducts.First().Name));  // Kiểm tra sản phẩm đầu tiên sau khi sắp xếp
        }

        [Test]
        public async Task GetProduct_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var product = _fixture.Create<Product>(); // Tạo sản phẩm giả
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().GetByIdAsync(product.Id))
                .ReturnsAsync(product);

            // Act
            var result = await _controller!.GetProduct(product.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ActionResult<Product>>());
            var returnedProduct = result?.Value as Product;
            Assert.That(returnedProduct, Is.Not.Null);
            Assert.That(returnedProduct?.Id, Is.EqualTo(product.Id));  // Kiểm tra Id sản phẩm trả về
            Assert.That(returnedProduct?.Name, Is.EqualTo(product.Name));  // Kiểm tra tên sản phẩm
        }

        [Test]
        public async Task GetProduct_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 999;  // ID không tồn tại
            _mockUnitOfWork?.Setup(uow => uow.Repository<Product>().GetByIdAsync(productId))
                .ReturnsAsync((Product?)null);  // Không tìm thấy sản phẩm

            // Act
            var result = await _controller!.GetProduct(productId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
            var notFoundResult = result.Result as NotFoundResult;
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));  // Kiểm tra mã trạng thái HTTP 404
        }
    }
}
