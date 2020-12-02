using AutoMapper;
using Products.Data.Entities;
using Products.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Help
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductIndexModel>()
                .ForMember((dest) => dest.CategoryName,
                opt => opt.MapFrom((s) => s.Category.Name))
                .ForMember((dest) => dest.SupplierName,
                opt => opt.MapFrom((s) => s.Supplier.SupplierName))
                 .ForMember((dest) => dest.CategoryName,
                opt => opt.MapFrom((s) => s.Category.Name))
                .ForMember((dest) => dest.ManufacturerName,
                opt => opt.MapFrom((s) => s.Manufacturer.ManufacturerName));
        }
    }
}
