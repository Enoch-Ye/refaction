using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using refactor_me.Services;
using refactor_me.Models;
using refactor_me.Data.Models.Products;
using refactor_me.Controllers;
using refactor_me.Models.ProductOptions;
using Ninject;
using refactor_me.Data.Persistence.Interfaces;
using refactor_me.Data.Persistence.Implementation;
using AutoMapper;
using refactor_me.Infra.Mapping;
using System.Linq;
using Ninject.MockingKernel.Moq;

namespace refactor_me.Test.Controllers
{
    /// <summary>
    /// Summary description for ProductsControllerTest
    /// </summary>
    [TestClass]
    public class ProductsControllerTest
    {
        // Moq Kernel Mocking instance
        private MoqMockingKernel _kernel;
        //Mock service
        private Mock<IService<ProductDTO, Product, ProductOptionDTO>> _service;

        /// <summary>
        /// Setup
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _kernel = new MoqMockingKernel();
            _service = _kernel.GetMock<IService<ProductDTO, Product, ProductOptionDTO>>();
            _service.Setup(d => d.GetAll()).Returns(new List<ProductDTO> { new ProductDTO(), new ProductDTO() });
            _service.Setup(d => d.Get(new Guid())).Returns(new ProductDTO() { ProductOptions = new List<ProductOptionDTO> { new ProductOptionDTO(), new ProductOptionDTO() } });
        }


        /// <summary>
        /// Test GetAll
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            var controller = new ProductsController(_service.Object);
            var response = controller.GetAll();
            Assert.AreEqual(response.Result.Items.Count, 2);
        }

        /// <summary>
        /// Test GetOptions
        /// </summary>
        [TestMethod]
        public void TestGetOptions()
        {
            var controller = new ProductsController(_service.Object);
            var response = controller.GetOptions(new Guid());
            Assert.AreEqual(response.Result.Items.Count, 2);
        }

        /// <summary>
        /// Tidy up
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //TODO
        }

    }
}
