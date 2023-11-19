using AutoMapper;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.SampleForms.Commands.DeleteSampleForm
{
    public class DeleteSampleFormCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteSampleFormCommandHandler : IRequestHandler<DeleteSampleFormCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<SampleForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteSampleFormCommandHandler(IRepositoryAsync<SampleForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteSampleFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sampleForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (sampleForm == null)
                    throw new KeyNotFoundException($"SampleForm con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(sampleForm);
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
