using AutoMapper;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace BackESPD.Application.Features.Users.Commands.ChangeUserRole
{
    public class ChangeUserRoleCommand : IRequest<GenericResponse<bool>>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    internal class ChangeUserRoleCommandHandler : IRequestHandler<ChangeUserRoleCommand, GenericResponse<bool>>
    {
             private readonly IRepositoryAsync<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> _repositoryAsync;
             private readonly IMapper _mapper;

        public ChangeUserRoleCommandHandler(IRepositoryAsync<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var user = await _repositoryAsync.GetAsync(p => p.UserId == request.UserId);
                if (user == null)
                    throw new KeyNotFoundException($"Usuario con el Id: {request.UserId} no existe");


                user.RoleId = request.RoleId;

                await _repositoryAsync.UpdateAsync(user);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }



}
