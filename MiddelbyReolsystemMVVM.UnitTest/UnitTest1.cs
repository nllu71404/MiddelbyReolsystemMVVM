using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiddelbyReolsystemMVVM.Repositories;
using MiddelbyReolsystemMVVM.Models;

namespace MiddelbyReolsystemMVVM.UnitTest
{
    [TestClass]
    public class FileRackRepositoryTest
    {
        [TestMethod]

        public void GetRack_ShouldReturnMatchingRack_WhenRackExists()
        {
            // Arrange
            var expectedRack = new Rack { RackNumber = "R123" };
            var racks = new List<Rack>
        {
            expectedRack,
            new Rack { RackNumber = "R456" }
        };

            var service = new TestableRackService(racks);

            // Act
            var result = service.GetRack(new Rack { RackNumber = "R123" });

            // Assert
            Assert.Equal(expectedRack, result);
        }

        [TestMethod]
        public void GetRack_ShouldReturnNull_WhenRackDoesNotExist()
        {
            // Arrange
            var racks = new List<Rack>
        {
            new Rack { RackNumber = "R456" }
        };

            var service = new TestableRackService(racks);

            // Act
            var result = service.GetRack(new Rack { RackNumber = "R999" });

            // Assert
            Assert.Null(result);
        }

        // Testklasse med mocket GetAll()
        private class TestableRackService : RackService
        {
            private readonly List<Rack> _racks;

            public TestableRackService(List<Rack> racks)
            {
                _racks = racks;
            }

            protected override IEnumerable<Rack> GetAll()
            {
                return _racks;
            }
        }

    }
