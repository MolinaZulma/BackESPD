using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.ActivityLogsForms.Queries.GetByIdActivityLogsForm
{
    public class GetByIdActivityLogsFormQuery : IRequest<GenericResponse<ActivityLogsFormDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdActivityLogsFormQueryHandler : IRequestHandler<GetByIdActivityLogsFormQuery, GenericResponse<ActivityLogsFormDto>>
    {
        private readonly IRepositoryAsync<ActivityLogsForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdActivityLogsFormQueryHandler(IRepositoryAsync<ActivityLogsForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ActivityLogsFormDto>> Handle(GetByIdActivityLogsFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var activityLogsForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (activityLogsForm == null)
                    throw new KeyNotFoundException($"ActivityLogsForm con el id: {request.Id} no existe");

                return new GenericResponse<ActivityLogsFormDto>(_mapper.Map<ActivityLogsFormDto>(activityLogsForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
