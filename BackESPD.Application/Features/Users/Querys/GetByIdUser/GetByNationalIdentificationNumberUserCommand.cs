using AutoMapper;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Users.Querys.GetByIdUser
{
    public class GetByNationalIdentificationNumberUserCommand : IRequest<GenericResponse<UserListDTO>>
    {
        public string NationalIdentificationNumber { get; set; }
    }

    internal class GetByNationalIdentificationNumberUserCommandHandler : IRequestHandler<GetByNationalIdentificationNumberUserCommand, GenericResponse<UserListDTO>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByNationalIdentificationNumberUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<UserListDTO>> Handle(GetByNationalIdentificationNumberUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repositoryAsync.GetAsync(tp => tp.NationalIdentificationNumber == request.NationalIdentificationNumber);
                if (user == null)
                    throw new KeyNotFoundException($"User con el NationalIdentificationNumber: {request.NationalIdentificationNumber} no existe");

                return new GenericResponse<UserListDTO>(_mapper.Map<UserListDTO>(user));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
