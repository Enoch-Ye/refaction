using AutoMapper;
using refactor_me.Data.Models.Products;
using refactor_me.Models;
using refactor_me.Models.ProductOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Infra.Mapping
{
    /// <summary>
    /// Automapper profile
    /// </summary>
    public class ModelMappingProfile : Profile
    {
        //Constructor
        public ModelMappingProfile()
        {
            DomainToDTO();
            DTOToDomain();
        }

        //Mapping from Domain to DTO
        public void DomainToDTO()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductOption, ProductOptionDTO>().ForSourceMember(d => d.Product, opt => opt.Ignore()).ForSourceMember(d => d.ProductId, opt => opt.Ignore());
        }

        //Mapping from DTO to Domain
        public void DTOToDomain()
        {
            CreateMap<ProductDTO, Product>().ForMember(d => d.ProductOptions, opt => opt.Ignore()).ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<ProductOptionDTO, ProductOption>().ForMember(d => d.Id, opt => opt.Ignore()).ForMember(d => d.Product, opt => opt.Ignore()).ForMember(d => d.ProductId, opt => opt.Ignore());
        }
    }
}