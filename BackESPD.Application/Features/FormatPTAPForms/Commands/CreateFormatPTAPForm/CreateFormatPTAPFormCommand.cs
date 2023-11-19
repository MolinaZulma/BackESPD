using AutoMapper;
using BackESPD.Application.DTOs.FormatPTAPForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.FormatPTAPForms.Commands.CreateFormatPTAPForm
{
    public class CreateFormatPTAPFormCommand : IRequest<GenericResponse<FormatPTAPFormDto>>
    {
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

    internal class CreateFormatPTAPFormCommandHandler : IRequestHandler<CreateFormatPTAPFormCommand, GenericResponse<FormatPTAPFormDto>>
    {
        private readonly IRepositoryAsync<FormatPTAPForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateFormatPTAPFormCommandHandler(IRepositoryAsync<FormatPTAPForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<FormatPTAPFormDto>> Handle(CreateFormatPTAPFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                FormatPTAPForm newFormatPTAPForm = _mapper.Map<CreateFormatPTAPFormCommand, FormatPTAPForm>(request);
                var formatPTAPForm = await _repositoryAsync.CreateAsync(newFormatPTAPForm);
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
