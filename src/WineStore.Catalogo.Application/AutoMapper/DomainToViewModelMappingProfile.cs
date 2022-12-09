using AutoMapper;
using WineStore.Catalogo.Application.ViewModels;
using WineStore.Catalogo.Domain;

namespace WineStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest=> dest.Largura, o=> o.MapFrom(src=> src.Dimensoes.Largura))
                .ForMember(dest=> dest.Altura, o=> o.MapFrom(src => src.Dimensoes.Altura))
                .ForMember(dest=> dest.Profundidade, o=> o.MapFrom(src => src.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
