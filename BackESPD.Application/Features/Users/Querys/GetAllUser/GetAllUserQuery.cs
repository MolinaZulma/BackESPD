using AutoMapper;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Users.Querys.GetAllUser
{
    public class GetAllUserQuery : IRequest<GenericResponse<List<UserListDTO>>>
    {
    }

    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GenericResponse<List<UserListDTO>>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<UserListDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<UserListDTO>>(_mapper.Map<List<UserListDTO>>(users));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
