using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.ActivityLogsForms.Commands.UpdateActivityLogsForm
{
    public class UpdateActivityLogsFormCommand : IRequest<GenericResponse<ActivityLogsFormDto>>
    {
        public int Id { get; set; }
        public string TypeActivity { get; set; }
        public string Observations { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class UpdateActivityLogsFormCommandHandler : IRequestHandler<UpdateActivityLogsFormCommand, GenericResponse<ActivityLogsFormDto>>
    {
        private readonly IRepositoryAsync<ActivityLogsForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateActivityLogsFormCommandHandler(IRepositoryAsync<ActivityLogsForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<GenericResponse<ActivityLogsFormDto>> Handle(UpdateActivityLogsFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var activityLogsForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (activityLogsForm == null)
                    throw new KeyNotFoundException($"ActivityLogsForm con el id: {request.Id} no existe");

                activityLogsForm.TypeActivity = request.TypeActivity;
                activityLogsForm.Observations = request.Observations;
                activityLogsForm.NationalIdentificationNumber = request.NationalIdentificationNumber;
                activityLogsForm.IdPlant = request.IdPlant;

                await _repositoryAsync.UpdateAsync(activityLogsForm);
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
