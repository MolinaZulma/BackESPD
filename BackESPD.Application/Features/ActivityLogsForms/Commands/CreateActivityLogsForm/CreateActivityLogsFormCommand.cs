using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.ActivityLogsForms.Commands.CreateActivityLogsForm
{
    public class CreateActivityLogsFormCommand : IRequest<GenericResponse<ActivityLogsFormDto>>
    {
        public string TypeActivity { get; set; }
        public string Observations { get; set; }
        public string IdUser { get; set; }
        public int IdPlant { get; set; }
    }

    internal class CreateActivityLogsFormCommandHandler : IRequestHandler<CreateActivityLogsFormCommand, GenericResponse<ActivityLogsFormDto>>
    {
        private readonly IRepositoryAsync<ActivityLogsForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateActivityLogsFormCommandHandler(IRepositoryAsync<ActivityLogsForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ActivityLogsFormDto>> Handle(CreateActivityLogsFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ActivityLogsForm newActivityLogsForm = _mapper.Map<CreateActivityLogsFormCommand, ActivityLogsForm>(request);
                var activityLogsForm = await _repositoryAsync.CreateAsync(newActivityLogsForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<ActivityLogsFormDto>(_mapper.Map<ActivityLogsFormDto>(activityLogsForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
