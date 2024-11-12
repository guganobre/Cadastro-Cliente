using AutoMapper;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;

namespace GestaoCliente.Core.Application.Helpers
{
    public static class AutoMapperHelper
    {
        public static void ConfigurationServiceMap(this IMapperConfigurationExpression config)
        {
            config.AutoMapperClienteDTO();
            config.AutoMapperEnderecoDTO();
        }

        public static void AutoMapperClienteDTO(this IMapperConfigurationExpression config)
        {
            config.CreateMap<ClienteDTORequest, Cliente>();
        }

        public static void AutoMapperEnderecoDTO(this IMapperConfigurationExpression config)
        {
            config.CreateMap<EnderecoDTORequest, Endereco>();
        }
    }
}