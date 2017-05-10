namespace Homemade.Run.App_Start
{
    using AutoMapper;
    using Homemade.Models.ViewModels;
    using Homemade.Models.EntityModels;
    using Homemade.Models.BindingModels;

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
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, from => from.Ignore())
                .ForMember(dest => dest.Description, from => from.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, from => from.MapFrom(src => src.Price))
                .ForMember(dest => dest.InOrders, from => from.Ignore());

                config.CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, from => from.MapFrom(src => src.Name));

                config.CreateMap<CartProduct, CartProductVM>()
                .ForMember(dest => dest.ProductId, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, from => from.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, from => from.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Quantity, from => from.MapFrom(src => src.Count));

                config.CreateMap<CartProduct, OrderProduct>()
                .ForMember(dest => dest.ProductId, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Order, from => from.Ignore())
                .ForMember(dest => dest.ProductId, from => from.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Product, from => from.Ignore())
                .ForMember(dest => dest.Count, from => from.MapFrom(src => src.Count));

                config.CreateMap<OrderProduct, ProductVM>()
                .ForMember(dest => dest.Name, from => from.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, from => from.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Count, from => from.MapFrom(src => src.Count));

                config.CreateMap<Order, OrderVM>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Buyer, from => from.MapFrom(src => src.Buyer))
                .ForMember(dest => dest.Confirmed, from => from.MapFrom(src => src.Confirmed))
                .ForMember(dest => dest.ShippingAddress, from => from.MapFrom(src => src.ShippingAddress))
                .ForMember(dest => dest.OrderedProducts, from => from.Ignore());

                config.CreateMap<Product, ProductBM>()
                .ForMember(dest => dest.Name, from => from.MapFrom(src => src.Name))
                .ForMember(dest => dest.Category, from => from.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, from => from.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, from => from.MapFrom(src => src.Price));
            });
        }
    }
}
