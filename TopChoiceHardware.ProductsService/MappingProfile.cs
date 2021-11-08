using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.ProductsService
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForCreation, Product>();
        }
    }
}
