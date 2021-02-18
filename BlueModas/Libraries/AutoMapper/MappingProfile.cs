using AutoMapper;
using BlueModas.Models;
using BlueModas.Models.ProdutoAgregador;

namespace BlueModas.Libraries.AutoMapper
{
    //NUGET-> AutoMapper.Extentions
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoItem>();
        }
    }
}
