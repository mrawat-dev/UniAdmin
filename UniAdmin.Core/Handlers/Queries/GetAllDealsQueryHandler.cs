using AutoMapper;
using UniAdmin.Contracts.Data;
using UniAdmin.Contracts.Data.Entities;
using UniAdmin.Contracts.DTO;
using MediatR;
using System.Linq;

namespace UniAdmin.Providers.Handlers.Queries
{
    public class GetAllDealsQuery : IRequest<IEnumerable<DealDTO>>
    {
    }

    public class GetAllDealsQueryHandler : IRequestHandler<GetAllDealsQuery, IEnumerable<DealDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllDealsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DealDTO>> Handle(GetAllDealsQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Deals.GetAll());
            return _mapper.Map<IEnumerable<DealDTO>>(entities);
        }
    }
}