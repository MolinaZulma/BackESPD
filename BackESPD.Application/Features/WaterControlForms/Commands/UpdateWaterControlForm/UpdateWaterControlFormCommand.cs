using AutoMapper;
using BackESPD.Application.DTOs.WaterControlForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.WaterControlForms.Commands.UpdateWaterControlForm
{
    public class UpdateWaterControlFormCommand : IRequest<GenericResponse<WaterControlFormDto>>
    {
        public int Id { get; set; }
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

    internal class UpdateWaterControlFormCommandHandler : IRequestHandler<UpdateWaterControlFormCommand, GenericResponse<WaterControlFormDto>>
    {
        private readonly IRepositoryAsync<WaterControlForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateWaterControlFormCommandHandler(IRepositoryAsync<WaterControlForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<WaterControlFormDto>> Handle(UpdateWaterControlFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var waterControlForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (waterControlForm == null)
                    throw new KeyNotFoundException($"WaterControlForm con el id: {request.Id} no existe");
                
                waterControlForm.TotalHours = request.TotalHours;
                waterControlForm.AmountWaterCaptured = request.AmountWaterCaptured;
                waterControlForm.AmountWaterSupplied = request.AmountWaterSupplied;
                waterControlForm.AluminumSulfate = request.AluminumSulfate;
                waterControlForm.SodiumHypochlorite = request.SodiumHypochlorite;
                waterControlForm.ChlorineGas = request.ChlorineGas;
                waterControlForm.ParticlesPerMillion = request.ParticlesPerMillion;
                waterControlForm.NationalIdentificationNumber = request.NationalIdentificationNumber;
                waterControlForm.IdPlant = request.IdPlant;

                await _repositoryAsync.UpdateAsync(waterControlForm);
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
