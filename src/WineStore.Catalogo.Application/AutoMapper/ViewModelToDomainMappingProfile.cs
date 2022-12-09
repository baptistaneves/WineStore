using AutoMapper;
using WineStore.Catalogo.Application.ViewModels;
using WineStore.Catalogo.Domain;

namespace WineStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(vm =>
                    new Produto(vm.Nome, vm.Descricao, vm.Valor,
                        vm.CategoriaId, vm.Ativo, vm.DataCadastro,
                        vm.Imagem, new Dimensoes(vm.Altura, vm.Largura, vm.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(vm => new Categoria(vm.Nome, vm.Codigo));
        }
    }
}
