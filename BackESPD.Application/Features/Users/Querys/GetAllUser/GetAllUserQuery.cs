using AutoMapper;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BackESPD.Application.Features.Users.Querys.GetAllUser
{
    public class GetAllUserQuery : IRequest<GenericResponse<List<UserListDTO>>>
    {
    }

    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GenericResponse<List<UserListDTO>>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IRepositoryAsync<IdentityRole> _repositoryAsyncRole;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public GetAllUserQueryHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper, IRepositoryAsync<IdentityRole> repositoryAsyncRole, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _repositoryAsyncRole = repositoryAsyncRole;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<GenericResponse<List<UserListDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var roles = _roleManager.Roles.ToList();
                var allUser = new List<UserListDTO>();
                foreach (var role in roles)
                {
                    var usersInRol = await _userManager.GetUsersInRoleAsync(role.Name);
                    allUser.AddRange(usersInRol.Select(p => new UserListDTO
                    {
                        Id = p.Id,
                        NationalIdentificationNumber = p.NationalIdentificationNumber,
                        Email = p.Email,
                        FullName = p.FullName,
                        PhoneNumber = p.PhoneNumber,
                        RoleName = role.Name,
                    }));
                }

                return new GenericResponse<List<UserListDTO>>(_mapper.Map<List<UserListDTO>>(allUser));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}