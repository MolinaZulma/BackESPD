using AutoMapper;
using BackESPD.Application.DTOs.WaterControlForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.WaterControlForms.Commands.CreateWaterControlForm
{
    public class CreateWaterControlFormCommand : IRequest<GenericResponse<WaterControlFormDto>>
    {
        public double TotalHours { get; set; }
        public double AmountWaterCaptured { get; set; }
        public double AmountWaterSupplied { get; set; }
        public double AluminumSulfate { get; set; }
        public double SodiumHypochlorite { get; set; }
        public double ChlorineGas { get; set; }
        public double ParticlesPerMillion { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class CreateWaterControlFormCommandHandler : IRequestHandler<CreateWaterControlFormCommand, GenericResponse<WaterControlFormDto>>
    {
        private readonly IRepositoryAsync<WaterControlForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateWaterControlFormCommandHandler(IRepositoryAsync<WaterControlForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<WaterControlFormDto>> Handle(CreateWaterControlFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                WaterControlForm newWaterControlForm = _mapper.Map<CreateWaterControlFormCommand, WaterControlForm>(request);
                var waterControlForm = await _repositoryAsync.CreateAsync(newWaterControlForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<WaterControlFormDto>(_mapper.Map<WaterControlFormDto>(waterControlForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
