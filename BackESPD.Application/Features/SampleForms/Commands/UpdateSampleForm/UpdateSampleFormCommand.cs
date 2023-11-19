using AutoMapper;
using BackESPD.Application.DTOs.SampleForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.SampleForms.Commands.UpdateSampleForm
{
    public class UpdateSampleFormCommand : IRequest<GenericResponse<SampleFormDto>>
    {
        public int Id { get; set; }
        public int SampleNumber { get; set; }
        public double MediumFlow { get; set; }
        public double TemperatureC { get; set; }
        public double Ph { get; set; }
        public double CreamWeightKilos { get; set; }
        public double SiftingWeightKilos { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class UpdateSampleFormCommandHandler : IRequestHandler<UpdateSampleFormCommand, GenericResponse<SampleFormDto>>
    {
        private readonly IRepositoryAsync<SampleForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateSampleFormCommandHandler(IRepositoryAsync<SampleForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<SampleFormDto>> Handle(UpdateSampleFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sampleForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (sampleForm == null)
                    throw new KeyNotFoundException($"SampleForm con el id: {request.Id} no existe");

                sampleForm.SampleNumber = request.SampleNumber;
                sampleForm.MediumFlow = request.MediumFlow;
                sampleForm.TemperatureC = request.TemperatureC;
                sampleForm.Ph = request.Ph;
                sampleForm.CreamWeightKilos = request.CreamWeightKilos;
                sampleForm.SiftingWeightKilos = request.SiftingWeightKilos;
                sampleForm.NationalIdentificationNumber = request.NationalIdentificationNumber;
                sampleForm.IdPlant = request.IdPlant;

                await _repositoryAsync.UpdateAsync(sampleForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<SampleFormDto>(_mapper.Map<SampleFormDto>(sampleForm));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
