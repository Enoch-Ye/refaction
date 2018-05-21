using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using refactor_me.Data.Models.Products;
using refactor_me.Data.Persistence.Interfaces;
using refactor_me.Models;
using refactor_me.Models.ProductOptions;
using refactor_me.Services;

namespace refactor_me.Controllers
{
    /// <summary>
    /// ProductsController
    /// </summary>
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        //service
        private readonly IService<ProductDTO, Product, ProductOptionDTO> _service;

        /// <summary>
        /// ProductsController Constructor
        /// </summary>
        /// <param name="service"></param>
        public ProductsController(IService<ProductDTO, Product, ProductOptionDTO> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public ApiResponse<ProductsDTO> GetAll()
        {
            try
            {
                ProductsDTO productsDTO = new ProductsDTO();
                productsDTO.Items = this._service.GetAll();
                return new ApiResponse<ProductsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "", Result = productsDTO };
            }
            catch (Exception ex) {
                return new ApiResponse<ProductsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// Search By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("{name}")]
        [HttpGet]
        public ApiResponse<ProductsDTO> SearchByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    ProductsDTO productsDTO = new ProductsDTO();
                    productsDTO.Items = this._service.RetrieveAll(d => string.Compare(name, d.Name, true) == 0);
                    return new ApiResponse<ProductsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "", Result = productsDTO };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:Guid}")]
        [HttpGet]
        public ApiResponse<ProductDTO> GetProduct(Guid id)
        {
            if (id != null)
            {
                ProductDTO productDTO = null;
                try
                {
                    productDTO = this._service.Get(id);
                    if (productDTO != null)
                    {
                        return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "", Result = productDTO };
                    }
                    else
                    {
                        return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public ApiResponse<ProductDTO> Create([FromBody]ProductDTO product)
        {
            if (product != null)
            {
                try
                {
                    this._service.Create(product);
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = ""};
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpPut]
        public ApiResponse<ProductDTO> Update(Guid id, [FromBody]ProductDTO product)
        {
            if (id != null && product != null)
            {
                try
                {
                    this._service.Update(id, product);
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public ApiResponse<ProductDTO> Delete(Guid id)
        {
            if (id != null)
            {
                try
                {
                    this._service.Delete(id);
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new ApiResponse<ProductDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Route("{productId}/options")]
        [HttpGet]
        public ApiResponse<ProductOptionsDTO> GetOptions(Guid productId)
        {
            if (productId != null)
            {
                try
                {
                    ProductOptionsDTO productOptionsDTO = new ProductOptionsDTO();
                    ProductDTO productDTO = this._service.Get(productId);
                    if (productDTO != null)
                    {
                        productOptionsDTO.Items = productDTO.ProductOptions;
                        return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "", Result = productOptionsDTO };
                    }
                    else
                    {
                        return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Get Options
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ApiResponse<ProductOptionsDTO> GetOption(Guid productId, Guid id)
        {
            if (productId != null && id != null)
            {
                try
                {
                    ProductOptionsDTO productOptionsDTO = new ProductOptionsDTO();
                    productOptionsDTO.Items = this._service.GetChildren(productId, id);
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "", Result = productOptionsDTO };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Create Option
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="option"></param>
        [Route("{productId}/options")]
        [HttpPost]
        public ApiResponse<ProductOptionsDTO> CreateOption(Guid productId, [FromBody]ProductOptionDTO option)
        {
            if (productId != null && option != null)
            {
                try
                {
                    ProductOptionsDTO productOptionsDTO = new ProductOptionsDTO();
                    this._service.CreateChild(productId, option);
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Update Option
        /// </summary>
        /// <param name="id"></param>
        /// <param name="option"></param>
        [Route("{productId}/options/{id}")]
        [HttpPut]
        public ApiResponse<ProductOptionsDTO> UpdateOption(Guid productId, Guid id, [FromBody]ProductOptionDTO option)
        {
            if (id != null && productId != null && option != null)
            {
                try
                {
                    this._service.UpdateChild(productId, id, option);
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }

        /// <summary>
        /// Delete Option
        /// </summary>
        /// <param name="id"></param>
        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public ApiResponse<ProductOptionsDTO> DeleteOption(Guid productId, Guid id)
        {
            if (id != null && productId != null)
            {
                try
                {
                    this._service.DeleteChild(productId, id);
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.OK, ErrorMessage = "" };
                }
                catch (Exception ex)
                {
                    return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
                }
            }
            return new ApiResponse<ProductOptionsDTO>() { StatusCode = (int)HttpStatusCode.BadRequest, ErrorMessage = "" };
        }
    }
}
