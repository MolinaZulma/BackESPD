using AutoMapper;
using BackESPD.Application.DTOs.SampleForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.SampleForms.Commands.CreateSampleForm
{
    public class CreateSampleFormCommand : IRequest<GenericResponse<SampleFormDto>>
    {
        public int SampleNumber { get; set; }
        public double MediumFlow { get; set; }
        public double TemperatureC { get; set; }
        public double Ph { get; set; }
        public double CreamWeightKilos { get; set; }
        public double SiftingWeightKilos { get; set; }
        public string IdUNationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class CreateSampleFormCommandHandler : IRequestHandler<CreateSampleFormCommand, GenericResponse<SampleFormDto>>
    {
        private readonly IRepositoryAsync<SampleForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateSampleFormCommandHandler(IRepositoryAsync<SampleForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<SampleFormDto>> Handle(CreateSampleFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                SampleForm newSampleForm = _mapper.Map<CreateSampleFormCommand, SampleForm>(request);
                var sampleForm = await _repositoryAsync.CreateAsync(newSampleForm);
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
