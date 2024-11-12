using AutoMapper;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Presentation.Web.Models;

namespace GestaoCliente.Presentation.Web.Helpers
{
    public static class AutoMapperHelper
    {
        public static IMapperConfigurationExpression ConfigurationApplicationMap(this IMapperConfigurationExpression config)
        {
            config.AutoMapperClienteViewModel();
            //config.AutoMapperEnderecoDTO();

            return config;
        }

        public static void AutoMapperClienteViewModel(this IMapperConfigurationExpression config)
        {
            config.CreateMap<ClienteViewModel, ClienteDTORequest>();

            config.CreateMap<Cliente, ClienteViewModel>();
        }

        //public static void AutoMapperEnderecoDTO(this IMapperConfigurationExpression config)
        //{
        //    config.CreateMap<EnderecoDTORequest, Endereco>();
        //}
    }
}