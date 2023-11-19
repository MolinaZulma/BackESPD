using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.ActivityLogsForms.Queries.GetAllActivityLogsForm
{
    public class GetAllActivityLogsFormQuery : IRequest<GenericResponse<List<ActivityLogsFormDto>>>
    {
    }

    internal class GetAllActivityLogsFormQueryHandler : IRequestHandler<GetAllActivityLogsFormQuery, GenericResponse<List<ActivityLogsFormDto>>>
    {
        private readonly IRepositoryAsync<ActivityLogsForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllActivityLogsFormQueryHandler(IRepositoryAsync<ActivityLogsForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<ActivityLogsFormDto>>> Handle(GetAllActivityLogsFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var activityLogsForm = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<ActivityLogsFormDto>>(_mapper.Map<List<ActivityLogsFormDto>>(activityLogsForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
