using AutoMapper;
using BackESPD.Application.DTOs.AspNetRoles;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.AspNetRoles.Queries.GetAllAspNetRoles
{
    public class GetAllAspNetRolesQuery : IRequest<GenericResponse<List<AspNetRolesDto>>>
    {
    }

    internal class GetAllAspNetRolesQueryHandler : IRequestHandler<GetAllAspNetRolesQuery, GenericResponse<List<AspNetRolesDto>>>
    {
        private readonly IRepositoryAsync<Roles> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllAspNetRolesQueryHandler(IRepositoryAsync<Roles> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<AspNetRolesDto>>> Handle(GetAllAspNetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Roles roles = new Roles();
                //roles.
                var roles = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<AspNetRolesDto>>(_mapper.Map<List<AspNetRolesDto>>(roles));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
