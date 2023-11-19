using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.DTOs.SampleForm;
using BackESPD.Application.Features.SampleForms.Commands.CreateSampleForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Application.Features.SampleForms.Queries.GetByIdSampleForm
{
    public class GetByIdSampleFormQuery : IRequest<GenericResponse<SampleFormDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdSampleFormQueryHandler : IRequestHandler<GetByIdSampleFormQuery, GenericResponse<SampleFormDto>>
    {
        private readonly IRepositoryAsync<SampleForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdSampleFormQueryHandler(IRepositoryAsync<SampleForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<SampleFormDto>> Handle(GetByIdSampleFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sampleForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (sampleForm == null)
                    throw new KeyNotFoundException($"SampleForm con el id: {request.Id} no existe");

                return new GenericResponse<SampleFormDto>(_mapper.Map<SampleFormDto>(sampleForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
