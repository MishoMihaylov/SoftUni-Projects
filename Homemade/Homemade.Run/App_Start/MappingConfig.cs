namespace Homemade.Run.App_Start
{
    using AutoMapper;
    using Homemade.Models.BindingModels;
    using Homemade.Models.EntityModels;

    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ProductBM, Product>()
                .ForMember(dest => dest.Name, from => from.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryId, from => from.MapFrom(src => src.Category))
                .ForMember(dest => dest.Category, from => from.Ignore())
                .ForMember(dest => dest.Date, from => from.Ignore())
                .ForMember(dest => dest.Price, from => from.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, from => from.MapFrom(src => src.Quantity));
            });
        }
    }
}