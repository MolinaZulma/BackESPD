using AutoMapper;
using BackESPD.Application.DTOs.FormatPTAPForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.FormatPTAPForms.Commands.UpdateFormatPTAPForm
{
    public class UpdateFormatPTAPFormCommand : IRequest<GenericResponse<FormatPTAPFormDto>>
    {
        public int Id { get; set; }
        public string TypeWater { get; set; }
        public double Temperature { get; set; }
        public double AlkalinityPh { get; set; }
        public double AlkalineChlorine { get; set; }
        public double AlkalineInitialReading { get; set; }
        public double AlkalineFinalReading { get; set; }
        public double AlkalineTotal { get; set; }
        public double Alkaline { get; set; }
        public double ChlorineGas { get; set; }
        public double ParticlesPerMillion { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class UpdateFormatPTAPFormCommandHandler : IRequestHandler<UpdateFormatPTAPFormCommand, GenericResponse<FormatPTAPFormDto>>
    {
        private readonly IRepositoryAsync<FormatPTAPForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateFormatPTAPFormCommandHandler(IRepositoryAsync<FormatPTAPForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<FormatPTAPFormDto>> Handle(UpdateFormatPTAPFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var formatPTAPForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (formatPTAPForm == null)
                    throw new KeyNotFoundException($"FormatPTAPForm con el id: {request.Id} no existe");

                formatPTAPForm.TypeWater = request.TypeWater;
                formatPTAPForm.Temperature = request.Temperature;
                formatPTAPForm.AlkalinityPh = request.AlkalinityPh;
                formatPTAPForm.AlkalineChlorine = request.AlkalineChlorine;
                formatPTAPForm.AlkalineInitialReading = request.AlkalineInitialReading;
                formatPTAPForm.AlkalineFinalReading = request.AlkalineFinalReading;
                formatPTAPForm.AlkalineTotal = request.AlkalineTotal;
                formatPTAPForm.Alkaline = request.Alkaline;
                formatPTAPForm.ChlorineGas = request.ChlorineGas;
                formatPTAPForm.ParticlesPerMillion = request.ParticlesPerMillion;
                formatPTAPForm.NationalIdentificationNumber = request.NationalIdentificationNumber;
                formatPTAPForm.IdPlant = request.IdPlant;

                await _repositoryAsync.UpdateAsync(formatPTAPForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<FormatPTAPFormDto>(_mapper.Map<FormatPTAPFormDto>(formatPTAPForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
