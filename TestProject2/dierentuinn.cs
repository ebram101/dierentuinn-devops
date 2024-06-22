using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dierentuinn.Controllers;
using dierentuinn.Data;
using dierentuinn.Models;
using Xunit;

namespace dierentuinn.Tests
{
    public class DierenControllerTests
    {
        private readonly Mock<DierentuinDbContext> _mockContext;
        private readonly DierenController _controller;
        private readonly List<Dieren> _dieren;
        private readonly Mock<DbSet<Dieren>> _mockSet;

        public DierenControllerTests()
        {
            _mockContext = new Mock<DierentuinDbContext>(new DbContextOptions<DierentuinDbContext>());
            _controller = new DierenController(_mockContext.Object);

            _dieren = new List<Dieren>
            {
                new Dieren { Id = 1, Name = "Lion", Species = "Panthera leo" },
                new Dieren { Id = 2, Name = "Tiger", Species = "Panthera tigris" }
            };

            _mockSet = new Mock<DbSet<Dieren>>();
            _mockSet.As<IQueryable<Dieren>>().Setup(m => m.Provider).Returns(_dieren.AsQueryable().Provider);
            _mockSet.As<IQueryable<Dieren>>().Setup(m => m.Expression).Returns(_dieren.AsQueryable().Expression);
            _mockSet.As<IQueryable<Dieren>>().Setup(m => m.ElementType).Returns(_dieren.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Dieren>>().Setup(m => m.GetEnumerator()).Returns(_dieren.AsQueryable().GetEnumerator());

            _mockContext.Setup(c => c.Dierens).Returns(_mockSet.Object);
            _mockContext.Setup(c => c.Dierens.FindAsync(It.IsAny<int>()))
                        .ReturnsAsync((int id) => _dieren.FirstOrDefault(d => d.Id == id));
        }

        [Fact]
        public void Index_ReturnsViewResult_WithAListOfDieren()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Dieren>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Details_ReturnsViewResult_WithDieren()
        {
            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Dieren>(viewResult.ViewData.Model);
            Assert.Equal("Lion", model.Name);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Act
            var result = _controller.Details(3);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndex_OnValidModel()
        {
            // Arrange
            var dier = new Dieren { Id = 3, Name = "Elephant", Species = "Loxodonta" };

            // Act
            var result = _controller.Create(dier);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockSet.Verify(m => m.Add(It.IsAny<Dieren>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

     

        [Fact]
        public void Edit_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Act
            var result = _controller.Edit(3);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_RedirectsToIndex_OnValidModel()
        {
            // Arrange
            var dier = new Dieren { Id = 1, Name = "Updated Lion", Species = "Panthera leo" };

            // Act
            var result = _controller.Edit(dier);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockContext.Verify(m => m.Update(It.IsAny<Dieren>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

    

        [Fact]
        public void Delete_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Act
            var result = _controller.Delete(3);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

       
        
    }
}
