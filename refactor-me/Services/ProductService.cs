using AutoMapper;
using Ninject;
using refactor_me.Data.Models.Products;
using refactor_me.Data.Persistence.Interfaces;
using refactor_me.Models;
using refactor_me.Models.ProductOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace refactor_me.Services
{
    /// <summary>
    /// Product Service
    /// </summary>
    public class ProductService : IService<ProductDTO, Product, ProductOptionDTO>
    {
        //product store
        private readonly IStore<Product> _store;
        //auto mapper
        private readonly IMapper _mapper;
        //product option store
        private readonly IStore<ProductOption> _optionStore;

        //Constructor
        public ProductService(IStore<Product> store, IMapper mapper, IStore<ProductOption> optionStore)
        {
            _store = store;
            _optionStore = optionStore;
            _mapper = mapper;
        }

        //Create
        public void Create(ProductDTO item)
        {
            Product product = new Product();
            _mapper.Map(item, product);
            this._store.Create(product);
        }

        //Get
        public ProductDTO Get(Guid id)
        {
            Product product = this._store.Get(id);
            ProductDTO productDTO = new ProductDTO();
            this._mapper.Map(product, productDTO);
            return productDTO;
        }

        //Update
        public void Update(Guid id, ProductDTO item)
        {
            Product product = this._store.Get(id);
            _mapper.Map(item, product);
            this._store.Update(product);
        }

        //Delete
        public void Delete(Guid id)
        {
            Product product = this._store.Get(id);
            this._store.Delete(product);
        }

        //GetAll
        public List<ProductDTO> GetAll()
        {
            List<Product> products = this._store.GetAll();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            _mapper.Map(products, productDTOs);
            return productDTOs;
        }

        //RetrieveAll
        public List<ProductDTO> RetrieveAll(Expression<Func<Product, bool>> exp)
        {
            List<Product> products = this._store.RetrieveAll(exp).ToList();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            _mapper.Map(products, productDTOs);
            return productDTOs;
        }

        //CreateChild
        public void CreateChild(Guid id, ProductOptionDTO child)
        {
            Product product = this._store.Get(id);
            ProductOption productOption = new ProductOption();
            this._mapper.Map(child, productOption);
            product.ProductOptions.Add(productOption);
            this._store.Update(product);
        }

        //UpdateChild
        public void UpdateChild(Guid id, Guid childId, ProductOptionDTO child)
        {
            Product product = this._store.Get(id);
            ProductOption productOption = product.ProductOptions.FirstOrDefault(d => d.Id == childId);
            if (productOption != null)
            {
                this._mapper.Map(child, productOption);
                this._store.Update(product);
            }
            else {
                throw new InvalidOperationException("Invalid product option");
            }
        }

        //DeleteChild
        public void DeleteChild(Guid id, Guid childId)
        {
            Product product = this._store.Get(id);
            ProductOption productOption = this._optionStore.Get(childId);
            if (productOption != null)
            {
                this._optionStore.Delete(productOption);
                this._store.SaveAll();
            }
            else {
                throw new InvalidOperationException("Invalid product option");
            }
        }

        //GetChildren
        public List<ProductOptionDTO> GetChildren(Guid id, Guid child)
        {
            ProductDTO productDTO = this.Get(id);
            return productDTO.ProductOptions.Where(d => d.Id == child).ToList();
        }
    }
}