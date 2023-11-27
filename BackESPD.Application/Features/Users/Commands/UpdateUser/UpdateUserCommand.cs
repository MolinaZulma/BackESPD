using AutoMapper;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<GenericResponse<UserListDTO>>
    {
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GenericResponse<UserListDTO>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<UserListDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repositoryAsync.GetAsync(tp => tp.NationalIdentificationNumber == request.NationalIdentificationNumber);
                if (user == null)
                    throw new KeyNotFoundException($"Usuario con cédula: {request.NationalIdentificationNumber} no existe");


                user.Email = request.Email;
                user.NormalizedEmail = request.Email.ToUpper();
                user.UserName = request.Email;
                user.NormalizedUserName = request.Email.ToUpper();
                user.FullName = request.FullName;
                user.PhoneNumber = request.PhoneNumber;

                await _repositoryAsync.UpdateAsync(user);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<UserListDTO>(_mapper.Map<UserListDTO>(user));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
