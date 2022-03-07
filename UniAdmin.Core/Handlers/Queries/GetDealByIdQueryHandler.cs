using MediatR;
using UniAdmin.Contracts.DTO;
using UniAdmin.Contracts.Data;
using UniAdmin.Core.Exceptions;
using AutoMapper;

namespace UniAdmin.Providers.Handlers.Queries
{
    public class GetDealByIdQuery : IRequest<DealDTO>
    {
        public int DealId { get; }
        public GetDealByIdQuery(int dealId)
        {
            DealId = dealId;
        }
    }

    public class GetDealByIdQueryHandler : IRequestHandler<GetDealByIdQuery, DealDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetDealByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DealDTO> Handle(GetDealByIdQuery request, CancellationToken cancellationToken)
        {
            var deal = await Task.FromResult(_repository.Deals.Get(request.DealId));

            if (deal == null)
            {
                throw new EntityNotFoundException($"No Deal found for Id {request.DealId}");
            }

            return _mapper.Map<DealDTO>(deal);
        }
    }
}