using AutoMapper;
using DataTransferObjects.Departments;
using DataTransferObjects.Products;
using DataTransferObjects.StockMovement;
using Models;

namespace SalesManager.API.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductGetDTO>().ReverseMap();
            CreateMap<Product, ProductPutDTO>().ReverseMap();
            CreateMap<Product, ProductPostDTO>().ReverseMap();

            CreateMap<Department, DepartmentGetDTO>().ReverseMap();
            CreateMap<Department, DepartmentPutDTO>().ReverseMap();
            CreateMap<Department, DepartmentPostDTO>().ReverseMap();

            CreateMap<StockMovement, StockMovementGetDTO>().ReverseMap();
            CreateMap<StockMovement, StockMovementPostDTO>().ReverseMap();
        }
    }
}
