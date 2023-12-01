using AutoMapper;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

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

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetByNationalIdentificationNumberUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<GenericResponse<UserListDTO>> Handle(GetByNationalIdentificationNumberUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = _roleManager.Roles.ToList();

                UserListDTO userDTO = null;

                foreach (var role in roles)
                {
                    var usersInRol = await _userManager.GetUsersInRoleAsync(role.Name);

                    var user = usersInRol.FirstOrDefault(u => u.NationalIdentificationNumber == request.NationalIdentificationNumber);

                    if (user != null)
                    {
                        userDTO = new UserListDTO
                        {
                            Id = user.Id,
                            NationalIdentificationNumber = user.NationalIdentificationNumber,
                            Email = user.Email,
                            FullName = user.FullName,
                            PhoneNumber = user.PhoneNumber,
                            RoleName = role.Name,
                        };

                        break;
                    }
                }

                return new GenericResponse<UserListDTO>(userDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
